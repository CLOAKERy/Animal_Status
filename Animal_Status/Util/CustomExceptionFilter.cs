using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Animal_Status.Util
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            
                // Логируем исключение, если необходимо
                // Log.Error(context.Exception);

                // Перенаправляем на страницу ошибки
                context.Result = new RedirectToActionResult("Error", "Home", new { message = context.Exception.Message });
                context.ExceptionHandled = true;
            
        }
    }
}
