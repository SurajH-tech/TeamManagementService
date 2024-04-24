using TMS.Application;
using TMS.Application.Extensions;
using TMS.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplicationServices();


var app = builder.Build();


// To Implement Logging feature we can utilise Application Insights service 
// Add Application Insights services to the services container.
// services.AddApplicationInsightsTelemetry(Configuration["ApplicationInsights:InstrumentationKey"]);


// Configure Application Insights logging level 
//services.AddLogging(builder =>
//{
//    builder.AddApplicationInsights();
//    builder.AddFilter<ApplicationInsightsLoggerProvider>("", LogLevel.Information);
//});


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
