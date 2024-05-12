using Animal_Status.Models;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AutoMapper;
using BLL.BusinessModel;
using Newtonsoft.Json;

namespace Animal_Status.Controllers
{
    
        public class AccountController : Controller
        {
            private readonly IAccountService accountService;
            private readonly IMapper mapper;

            public AccountController(IAccountService accountService, IMapper mapper)
            {
                this.accountService = accountService;
                this.mapper = mapper;
            }

            

            [HttpPost]
            public async Task<IActionResult> Register(AccountViewModel model)
            {
                ModelState.Remove("loginViewModel");
                TempData["AccountViewModel"] = JsonConvert.SerializeObject(model); // Сохраняем модель в TempData
                return RedirectToAction("Confirm", "Account");
        }

            [HttpGet]
            public IActionResult Confirm()
            {
            var json = TempData["AccountViewModel"] as string; // Получаем JSON строку из TempData
            var model = JsonConvert.DeserializeObject<AccountViewModel>(json); // Десериализуем JSON строку в объект модели
            model.Code = RandomCodeGenerator.GenerateCode(8);
                EmailSender.SendMessage(model.Code, model.registerViewModel.Email);
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> ConfirmComplete(AccountViewModel model)
            {   
                if(model.Code == model.CodeFromForm)
                {
                    ModelState.Remove("loginViewModel");
                    if (ModelState.IsValid)
                    {
                        UserDTO userDTO = mapper.Map<RegisterViewModel, UserDTO>(model.registerViewModel);
                        var response = await accountService.Register(userDTO);
                        if (response is ClaimsIdentity)
                        {
                            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                new ClaimsPrincipal(response));

                            return RedirectToAction("Index", "Home");
                        }
                        ModelState.AddModelError("", "Пользователь уже есть");
                    }
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    TempData["AccountViewModel"] = JsonConvert.SerializeObject(model); // Сохраняем модель в TempData
                    return RedirectToAction("Confirm", "Account");
            }

                }

            [HttpGet]
            public IActionResult Login() => View();

            [HttpPost]
            public async Task<IActionResult> Login(AccountViewModel model)
            {
            
            ModelState.Remove("registerViewModel");
            ModelState.Remove("CodeFromForm");
            ModelState.Remove("Code");

            if (ModelState.IsValid)
                {
                    UserDTO userDTO = mapper.Map<LoginViewModel, UserDTO>(model.loginViewModel);
                    var response = await accountService.Login(userDTO);
                    if (response is ClaimsIdentity)
                    {
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(response));

                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "Не верный логин");
                }
            return RedirectToAction("Index", "Home");
            }

            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Logout()
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Index", "Home");
            }
        }
}

