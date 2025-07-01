using Microsoft.EntityFrameworkCore;
using MyBackendApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add SQL Server DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => 
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");

app.UseSwagger();         // ✅ Generate Swagger JSON
app.UseSwaggerUI();       // ✅ Serve Swagger UI

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
