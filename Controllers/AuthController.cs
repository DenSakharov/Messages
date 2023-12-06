using Microsoft.AspNetCore.Mvc;
using API_Mes.Services;
using API_Mes.Models;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly MessageService _messageService;

    public AuthController(MessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequestModel model)
    {
        // Проверка учетных данных (пример)
        if (model.Login == "1" && model.Password == "1")
        {
            // Ваши действия после успешной аутентификации
            var token = "your_generated_token"; // Здесь обычно генерируется токен для аутентифицированного пользователя
            return Ok(new { Token = token });
        }

        // Ваши действия при неудачной аутентификации
        return Unauthorized(new { Error = "Authentication failed" });
    }
}
