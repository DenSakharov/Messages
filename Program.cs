using API_Mes.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

var builder = WebApplication.CreateBuilder(args);

// ���������� ������� ��� ���������� �����������
builder.Services.AddSingleton<MessageService>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// ���������� ������������
builder.Services.AddControllers();
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "front/build"; // ��������� ���� � ����������� ������ React
});

var app = builder.Build();

// ������������� �������������
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
            // ������������ ������
            // var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
            // logger.LogError($"Something went wrong: {error.Error}");

            await context.Response.WriteAsync($"{{ \"error\": \"{error.Error.Message}\" }}");
        }
    });
});
app.UseCors();

// ������������� ������������
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
        app.UseDeveloperExceptionPage(); // ���������� �������� � ����������� �� ������� � ������ ����������
        app.UseHttpsRedirection(); // ��������������� � HTTP �� HTTPS
    }
});

app.Run();