using Microsoft.EntityFrameworkCore;
using SWD_BloodDonation.Models;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký DbContext với Connection String từ appsettings.json
builder.Services.AddDbContext<BloodDonationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

// Bật swagger dù ở môi trường nào (Azure không phải là Development nên bạn cần bật thủ công)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Tạo scope để chạy migration (bạn có thể mở lại khi DB đã ổn định)
// using (var scope = app.Services.CreateScope())
// {
//     var db = scope.ServiceProvider.GetRequiredService<BloodDonationContext>();
//     db.Database.Migrate();
// }

// Bật swagger UI luôn cho tiện test (bạn có thể giới hạn lại môi trường nếu muốn)
app.UseSwagger();
app.UseSwaggerUI();

// Bật HTTPS redirect nếu muốn (Azure App Service hỗ trợ HTTPS)
// app.UseHttpsRedirection();

// Nếu bạn có Authentication, bật Authorization
// app.UseAuthorization();

app.MapControllers();

// Nếu Azure yêu cầu app lắng nghe ở cổng trong biến môi trường PORT, thì thiết lập lại Kestrel:
var portEnv = Environment.GetEnvironmentVariable("PORT");
if (!string.IsNullOrEmpty(portEnv) && int.TryParse(portEnv, out var port))
{
    app.Urls.Clear();
    app.Urls.Add($"http://*:{port}");
}

app.Run();
