using Microsoft.EntityFrameworkCore;
using SWD_BloodDonation.Models; // Đảm bảo namespace này là chính xác cho BloodDonationContext và các Models của bạn

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Đăng ký DbContext với Connection String từ appsettings.json
builder.Services.AddDbContext<BloodDonationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

// BỔ SUNG: Cấu hình Swagger/OpenAPI Services
builder.Services.AddEndpointsApiExplorer(); // Cần thiết cho Swagger
builder.Services.AddSwaggerGen(); // Cần thiết cho Swagger

var app = builder.Build();

// CHẠY MIGRATION trước khi app chạy (Tự động tạo / cập nhật DB trên Azure)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BloodDonationContext>();
    //db.Database.Migrate(); // Tự động tạo / cập nhật DB trên Azure - đã được comment để tránh lỗi "object already exists"
}

// BỔ SUNG: Cấu hình HTTP Request Pipeline cho Swagger
// Thường chỉ kích hoạt Swagger trong môi trường Development để bảo mật
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Bật middleware Swagger (tạo ra JSON API spec)
    app.UseSwaggerUI(); // Bật middleware Swagger UI (giao diện web)
}

// Nếu bạn muốn dùng HTTPS redirection và Authorization, hãy thêm chúng vào
// app.UseHttpsRedirection();
// app.UseAuthorization();

app.MapControllers(); // Ánh xạ các controller

app.Run();