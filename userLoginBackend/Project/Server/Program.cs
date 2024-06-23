
using Microsoft.EntityFrameworkCore;
using DAL.models;
using DAL.Interfaces;
using DAL.functions;
using BLL.interfaces;
using BLL.functions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<Iuser, userDal>();
builder.Services.AddScoped<Ireport, reportDal>();
builder.Services.AddScoped<Ilog, logDal>();
builder.Services.AddScoped<IActivityLog_bll, ActivityLog_bll>();
builder.Services.AddScoped<IReport_bll, Report_bll>();
builder.Services.AddScoped<Iuser_bll, User_bll>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LoginContext>(options => options.UseSqlServer("Server=DESKTOP-AEGJR0O;Database=Login;Trusted_Connection=True;TrustServerCertificate=True;"));
builder.Services.AddCors(p => p.AddPolicy("corspolicy", builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corspolicy");
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();
app.Run();
