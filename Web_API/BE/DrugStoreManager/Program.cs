using DrugStoreManager.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//??ng k� database
builder.Services.AddDbContext<MyDbContext>(otp =>
{
    otp.UseSqlServer(builder.Configuration.GetConnectionString("MyDB"));
});
// ??ng k� host c� th? truy c?p
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
// s? d?ng host c� th? truy c?p
app.UseCors("AllowAllOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
