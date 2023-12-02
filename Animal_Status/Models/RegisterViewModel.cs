using System.ComponentModel.DataAnnotations;
namespace Animal_Status.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите email")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = " Введите имя")]
        [MinLength(3, ErrorMessage = "Имя должно иметь длину больше 3 символов")]
        [MaxLength(10, ErrorMessage = "Имя должно иметь длину не больше 10 символов")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = " Введите пароль")]
        [MinLength(6, ErrorMessage = "Пароль должен иметь длину больше 6 символов")]
        [MaxLength(20, ErrorMessage = "Пароль должен иметь длину не больше 20 символов")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
    }
}
