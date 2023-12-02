using Animal_Status.Models;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AutoMapper;

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

            [HttpGet]
            public IActionResult Login() => View();

            [HttpPost]
            public async Task<IActionResult> Login(AccountViewModel model)
            {

            ModelState.Remove("registerViewModel");

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

