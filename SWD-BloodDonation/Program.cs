using Microsoft.EntityFrameworkCore;
using SWD_BloodDonation.Models;


var builder = WebApplication.CreateBuilder(args);

// Đăng ký DbContext và sử dụng connection string trong appsettings.json
builder.Services.AddDbContext<BloodDonationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
