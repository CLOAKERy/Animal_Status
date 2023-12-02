using System.ComponentModel.DataAnnotations;
namespace Animal_Status.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите email")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = " Введите пароль")]
        [MinLength(6, ErrorMessage = "Пароль должен иметь длину больше 6 символов")]
        [MaxLength(20, ErrorMessage = "Пароль должен иметь длину не больше 20 символов")]
        public string Password { get; set; }
    }
}
