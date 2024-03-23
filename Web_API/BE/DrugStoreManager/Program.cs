using DrugStoreManager.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//??ng ký database
builder.Services.AddDbContext<MyDbContext>(otp =>
{
    otp.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));
});
// ??ng ký host có th? truy c?p
builder.Services.AddCors(otp=>
{
    otp.AddPolicy("AllowAllOrigin", builder =>
    {
        builder.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// s? d?ng host có th? truy c?p
app.UseCors("AllowAllOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
