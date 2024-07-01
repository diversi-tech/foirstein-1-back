
using Microsoft.EntityFrameworkCore;
using DAL.models;
using DAL.Interfaces;
using DAL.functions;
using BLL.interfaces;
using BLL.functions;
using AutoMapper;
using BLL.AutoMapper;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//var mapperConfig = new MapperConfiguration(mc =>
//{
//    mc.AddProfile(new AutoMapperProfile());
//});
//IMapper mapper = mapperConfig.CreateMapper();
//builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<Iuser, userDal>();
builder.Services.AddScoped<Ireport, reportDal>();
builder.Services.AddScoped<Ilog, logDal>();
builder.Services.AddScoped<IActivityLog_bll, ActivityLog_bll>();
builder.Services.AddScoped<IReport_bll, Report_bll>();
builder.Services.AddScoped<Iuser_bll, User_bll>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LiberiansDbContext>(options => options.UseSqlServer("Server=localhost,1433;Database=liberiansDB;Trusted_Connection=True;TrustServerCertificate=True;"));
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
