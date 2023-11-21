using API_Mes.Services;

var builder = WebApplication.CreateBuilder(args);

// ���������� ������� ��� ���������� �����������
builder.Services.AddSingleton<MessageService>();

// ���������� ������������
builder.Services.AddControllers();

var app = builder.Build();

// ������������� �������������
app.UseRouting();

// ������������� ������������
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();