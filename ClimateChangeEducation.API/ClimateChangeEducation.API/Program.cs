using ClimateChangeEducation.Common.Configurations;
using ClimateChangeEducation.Common.Helpers;
using ClimateChangeEducation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

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


// Add services to the container.
builder.Services.AddControllers();
//builder.Services.Configure<ClimateDbSetting>(builder.Configuration.GetSection("DbConnectionStrings"));
builder.Services.Configure<EmailLoginSetting>(builder.Configuration.GetSection("MailLoginDetails"));


//database setup
builder.Services.AddDbContext<ClimateDataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});




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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
