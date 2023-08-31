using ClimateChangeEducation.Application.Interfaces;
using ClimateChangeEducation.Application.Services;
using ClimateChangeEducation.Common.Configurations;
using ClimateChangeEducation.Common.Helpers;
using ClimateChangeEducation.Domain.Entities;
using ClimateChangeEducation.Infrastructure.Data;
using ClimateChangeEducation.Infrastructure.Interfaces;
using ClimateChangeEducation.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.DataProtection;
using ClimateChangeEducation.Infrastructure.Helpers;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

//serilog logger config
var logger = new LoggerConfiguration()
   .ReadFrom.Configuration(builder.Configuration)
   .Enrich.FromLogContext()
   .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

//AutoMapper configuration
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

//builder.Services.AddCors((options) =>
//{
//    options.AddPolicy("angularApplication", (builder) =>
//    {
//        builder.WithOrigins("http://localhost:4200")
//        .AllowAnyHeader()
//        .WithMethods("GET", "POST", "PUT", "DELETE")
//        .WithExposedHeaders("*");
//    });
//});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Add your frontend URL
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
 

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(
    options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

//builder.Services.Configure<ClimateDbSetting>(builder.Configuration.GetSection("DbConnectionStrings"));
builder.Services.Configure<EmailLoginSetting>(builder.Configuration.GetSection("MailLoginDetails"));


//database setup
builder.Services.AddDbContext<ClimateDataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//JWT config settings

builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ClimateDataContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedAccount = true; // Require confirmed email
});

//builder.Services.AddDataProtection()
//                .ProtectKeysWithDpapi();

                //.PersistKeysToDbContext<ClimateDataContext>();
                //.SetApplicationName("ClimateWebapp")
                //.SetDefaultKeyLifetime(TimeSpan.FromDays(180));

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
  .AddJwtBearer(o =>
  {
      o.RequireHttpsMetadata = false;
      o.SaveToken = false;
      o.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuerSigningKey = true,
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ClockSkew = TimeSpan.Zero,
          ValidIssuer = builder.Configuration["JWT:Issuer"],
          ValidAudience = builder.Configuration["JWT:Audience"],
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
      };
  });



//

builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IDiscussionBoardRepository, DiscussionBoardRepository>();
builder.Services.AddScoped<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
builder.Services.AddScoped<ILocalImageStorageRepository, LocalImageStorageRepository>();
builder.Services.AddScoped<IContactUsRepository, ContactUsRepository>();
builder.Services.AddScoped<INoticeBoardRepository, NoticeBoardRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();


//builder.Services.AddScoped<IHostEnvironment>();










// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();  
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
