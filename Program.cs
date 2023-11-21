using API_Mes.Services;

var builder = WebApplication.CreateBuilder(args);

// Добавление сервиса для управления сообщениями
builder.Services.AddSingleton<MessageService>();

// Добавление контроллеров
builder.Services.AddControllers();

var app = builder.Build();

// Использование маршрутизации
app.UseRouting();

// Использование контроллеров
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();