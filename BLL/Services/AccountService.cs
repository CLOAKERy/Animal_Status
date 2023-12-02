using Animal_Status;
using AnimalRepair.BLL.Infrastructure;
using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ClaimsIdentity> Register(UserDTO userDTO)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByEmailAsync(userDTO.Email);
                if (user != null)
                {
                    throw new ValidationException("Такой email уже занят", "");
                }
                // Валидация данных 
                if (string.IsNullOrEmpty(userDTO.Email.ToString()))
                    throw new ValidationException("Email не может быть пустым", "");
                if (string.IsNullOrEmpty(userDTO.Password.ToString()))
                    throw new ValidationException("Пароль не может быть пустым", "");

                UserDTO userRegister = new()
                {
                    Name = userDTO.Name,
                    Email = userDTO.Email,
                    Password = userDTO.Password,
                    RoleId = 1
                };


                // Пример сохранения в базу данных с использованием UnitOfWork
                await _unitOfWork.Users.CreateAsync(_mapper.Map<UserDTO, User>(userRegister));
                _unitOfWork.Save();

                var userlast = await _unitOfWork.Users.GetLastAsync();
                var userLogin = _mapper.Map<User, UserDTO>(userlast);


                var result = Authenticate(userLogin);

                return result;

            }
            catch
            {
                throw new ValidationException("Не работает", "");

            }
        }

        public async Task<ClaimsIdentity> Login(UserDTO userDTO)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByEmailAsync(userDTO.Email);
                if (user == null)
                {
                    throw new ValidationException("Пользователь не найден", "");
                }

                if (user.Password != userDTO.Password)
                {
                    throw new ValidationException($"Неверный логин или пароль", "");
                }

                var result = Authenticate(userDTO);

                return result;
            }
            catch (Exception ex)
            {
                throw new ValidationException(ex.Message, "");
            }
        }



        private ClaimsIdentity Authenticate(UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserId.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.RoleId.ToString())
                
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
