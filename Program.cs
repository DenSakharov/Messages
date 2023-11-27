using API_Mes.Services;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;

var builder = WebApplication.CreateBuilder(args);

// ���������� ������� ��� ���������� �����������
builder.Services.AddSingleton<MessageService>();

// ���������� ������������
builder.Services.AddControllers();
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "front/build"; // ��������� ���� � ����������� ������ React
});

var app = builder.Build();

// ������������� �������������
app.UseRouting();

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
    }
});

app.Run();