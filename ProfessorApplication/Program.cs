using Domain.Queue.Interface;
using Domain.Queue.Service;
using Hangfire;
using Hangfire.Common;
using IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHealthChecks().ForwardToPrometheus();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProfessorApplication-API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Jwt Auth",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme{ Reference = new OpenApiReference
            {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
            }
        },
            new string[]{}
            }


    });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
    };
});

builder.Services.AddHangfireServer();
builder.Services.AddHangfire(configuration =>
{
    configuration.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();
var customMetric = Metrics.CreateGauge("custom_metric1", "Custom metric 1");
customMetric.Set(42);
var customMetric2 = Metrics.CreateCounter("custommetric2", "Custom metric 2");
customMetric2.Inc(1);

//app.UseHangfireDashboard("/dash");
//app.UseHangfireServer();
//var queueService = new QueueService();
//app.MapGet("/consume", () => queueService.Consume());
//var manager = new RecurringJobManager();
//manager.AddOrUpdate("consume", Job.FromExpression(() => queueService.Consume()), Cron.Minutely());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMetricServer();
app.UseHttpMetrics();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
