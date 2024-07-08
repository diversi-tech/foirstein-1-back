using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DAL.models;
using DAL.Interfaces;
using DAL.functions;
using BLL.interfaces;
using BLL.functions;
using AutoMapper;
using BLL.AutoMapper;
using userLoginBackend.models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// שירותי התלותות שלך
builder.Services.AddScoped<Iuser, userDal>();
builder.Services.AddScoped<Ireport, reportDal>();
builder.Services.AddScoped<Ilog, logDal>();
builder.Services.AddScoped<IActivityLog_bll, ActivityLog_bll>();
builder.Services.AddScoped<IReport_bll, Report_bll>();
builder.Services.AddScoped<Iuser_bll, User_bll>();
builder.Services.AddScoped<IsearchLog, searchLogDal>();
builder.Services.AddScoped<ISearchLogBll, SearchLogBll>();
builder.Services.AddScoped<IBorrowApprovalRequestsBll, BorrowApprovalRequestBll>();
builder.Services.AddScoped<IBorrowApprovalRequests, BorrowApprovalRequestsDal>();
builder.Services.AddScoped<Iitem, ItemDal>();
builder.Services.AddScoped<Irating, ratingDal>();
builder.Services.AddScoped<IItem_bll, BLL.functions.Item>();
builder.Services.AddScoped<IRatingNote_bll, RatingNote_bll>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// הגדרת EF Core עם SQL Server
builder.Services.AddDbContext<DAL.models.LiberiansDbContext>(options => options.UseSqlServer("Server=localhost,1433;Database=liberiansDB;Trusted_Connection=True;TrustServerCertificate=True;"));

// הגדרת Cors
builder.Services.AddCors(p => p.AddPolicy("corspolicy", builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

// הגדרת Authentication ו-JWT Bearer
var key = Encoding.UTF8.GetBytes("YourSuperSecretKeyThatIsAtLeast32CharactersLong");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "yourdomain.com",
        ValidAudience = "yourdomain.com",
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");
app.UseHttpsRedirection();

app.UseAuthentication(); // הוסף את השורה הזו
app.UseAuthorization();

app.MapControllers();
app.Run();
