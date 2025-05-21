using Microsoft.EntityFrameworkCore;
using SWD_BloodDonation.Models;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký DbContext với Connection String từ appsettings.json hoặc Azure Configuration
builder.Services.AddDbContext<BloodDonationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

// CHẠY MIGRATION trước khi app chạy
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BloodDonationContext>();
    db.Database.Migrate(); // Tự động tạo / cập nhật DB trên Azure
}

app.MapControllers();

app.Run();
