using Application.Core;
using Application.Sentences;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace DynamicBuild.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
           IConfiguration config)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            //var hostname = Environment.GetEnvironmentVariable("SQLSERVER_HOST") ?? "mssqlserver";
            //var password = Environment.GetEnvironmentVariable("SA_PASSWORD") ?? "BuildWord!123";
            //var database = Environment.GetEnvironmentVariable("DATABASE") ?? "DynamicBuildDb";

            var hostname = Environment.GetEnvironmentVariable("SQLSERVER_HOST") ?? "mssqlserver";
            var password = Environment.GetEnvironmentVariable("SA_PASSWORD") ?? "DevAgain!1";
            var database = Environment.GetEnvironmentVariable("DATABASE") ?? "DynamicBuildDb";

            //var connectionString = $"Server={hostname};Database={database};User ID=sa;Password={password};";

            //var connectionString = "Server=mssqlserver;Database=DynamicBuildDb;User ID=sa;Password=BuildWord!123;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True";
            var connectionString = "Server=tcp:runninghilltest.database.windows.net,1433;Initial Catalog=DynamicBuildDb;Persist Security Info=False;User ID=runninghilltest;Password=DevAgain!1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //var connectionString = "Server=mssqlserver;Database=DynamicBuildDb;User ID=sa;Password=BuildWord!123;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True";

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connectionString,
                sqlServerOptionsAction: sqlOptions =>
                {
                 sqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                });
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins("http://localhost:4200");
                });
            });
            services.AddMediatR(typeof(List.Handler));
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<Create>();
            services.AddHttpContextAccessor();
            services.AddSignalR();

            return services;
        }
    }
}
