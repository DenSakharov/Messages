using API_Mes.Services;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

var builder = WebApplication.CreateBuilder(args);

// Добавление сервиса для управления сообщениями
builder.Services.AddSingleton<MessageService>();

// Добавление контроллеров
builder.Services.AddControllers();
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "front/build"; // Указываем путь к статическим файлам React
});

var app = builder.Build();

// Использование маршрутизации
app.UseRouting();

// Использование контроллеров
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "front";

    if (app.Environment.IsDevelopment())
    {
        spa.UseReactDevelopmentServer(npmScript: "start");
    }
});

app.Run();