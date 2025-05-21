using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký services



var app = builder.Build();

// Map controllers
app.MapControllers();

app.Run();
