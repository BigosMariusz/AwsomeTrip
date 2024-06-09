using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using MediatR;
using FluentValidation;
using MariuszCompany.AwsomeTrip.Application.PiplinesBehaviours;
using Serilog;
using System.Diagnostics;
using MariuszCompany.AwsomeTrip.Application.Mappings;
using MariuszCompany.AwsomeTrip.Infrastructure.DbContexts;
using MariuszCompany.AwsomeTrip.Api.Middlewares;
using Microsoft.Extensions.Options;
using MariuszCompany.AwsomeTrip.Application.Interfaces.Repositories;
using MariuszCompany.AwsomeTrip.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;
namespace MariuszCompany.AwsomeTrip.Api
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Awsome Trip - Api", Version = "v1.1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<ITripRepository, TripRepository>();
            builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
            builder.Services.AddScoped<ITripListRepository, TripListRepository>();

            builder.Services.AddDbContext<AppDbContext>(op => op.UseInMemoryDatabase("TripsDb"));

            builder.Services.AddValidatorsFromAssembly(typeof(MappingProfile).Assembly);
            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(MappingProfile).Assembly);
            });
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            builder.Host.UseSerilog((ctx, lc) => lc
                .ReadFrom.Configuration(ctx.Configuration));

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSerilogRequestLogging();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AwsomeTrip.Api v1.1");
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
