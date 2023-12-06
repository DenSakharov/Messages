using API_Mes.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

var builder = WebApplication.CreateBuilder(args);

// Добавление сервиса для управления сообщениями
builder.Services.AddSingleton<MessageService>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Добавление контроллеров
builder.Services.AddControllers();
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "front/build"; // Указываем путь к статическим файлам React
});

var app = builder.Build();

// Использование маршрутизации
app.UseRouting();
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";

        var error = context.Features.Get<IExceptionHandlerFeature>();
        if (error != null)
        {
            // Логгирование ошибки
            // var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
            // logger.LogError($"Something went wrong: {error.Error}");

            await context.Response.WriteAsync($"{{ \"error\": \"{error.Error.Message}\" }}");
        }
    });
});
app.UseCors();

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
        app.UseDeveloperExceptionPage(); // Показывать страницу с информацией об ошибках в режиме разработки
        app.UseHttpsRedirection(); // Перенаправление с HTTP на HTTPS
    }
});

app.Run();