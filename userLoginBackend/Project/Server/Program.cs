//using Bl;
//using Bl.BlApi;
//using Bl.Blservices;
//using Dal;
//using Dal.DalApi;
//using Dal.Models;
//using Dal.Services;
//using DataAccess;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();

////builder.Services.AddSingleton<DalManager>();
//builder.Services.AddSingleton<BlManager>();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

////builder.Services.AddScoped<Dal.DalApi.IDietitianService, Dal.Services.DietitianService>();
////builder.Services.AddScoped<IBlDietitianService, BlDietitianService>();
//DBActions db = new DBActions(builder.Configuration);
//string connStr = db.GetConnectionString("ClinicContext");
//builder.Services.AddDbContext<NutritionContext>(opt => opt.UseSqlServer(connStr));
//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
using Bl;
using Dal;
using Microsoft.EntityFrameworkCore;

using Bl;
using Microsoft.EntityFrameworkCore;
using DAL.models;
using DAL.Interfaces;
using DAL.functions;
using BLL.interfaces;
using BLL.functions;
using AutoMapper;
using BLL.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
//builder.Services.AddScoped<IActivityLog_bll, ActivityLog_bll>();
//builder.Services.AddScoped<IReport_bll, Report_bll>();
builder.Services.AddScoped<Iuser_bll, User_bll>();

builder.Services.AddScoped<Iuser, userDal>();
//builder.Services.AddScoped<Ireport, reportDal>();
//builder.Services.AddScoped<Ilog, logDal>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LoginContext>(options => options.UseSqlServer("Server=DESKTOP-L9S4R74;Database=Login;Trusted_Connection=True;TrustServerCertificate=True;"));
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
