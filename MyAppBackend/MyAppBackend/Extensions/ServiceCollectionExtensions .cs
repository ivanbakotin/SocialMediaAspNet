using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MyAppBackend.Data;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.Models;
using MyAppBackend.Services.Auth;
using MyAppBackend.Services.Email;
using MyAppBackend.Services.PostService;

namespace MyAppBackend.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection addJwtAuthenticationExtension(this IServiceCollection services)
        {
            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {       
                options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "https://localhost:5001",
                ValidAudience = "https://localhost:5001",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretkeysecretkeysecretkeysecretkey"))
            };
            });

            return services;
        }

        public static IServiceCollection addCorsExtension(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            return services;
        }

        public static IServiceCollection addEmailExtension(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSingleton(
                Configuration
                    .GetSection("EmailConfiguration")
                    .Get<ResetEmail>()
            );

            return services;
        }

        public static IServiceCollection addDbContextExtension(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options => {
                options.UseSqlServer("WebApiDatabase");
            });

            return services;
        }

        public static IServiceCollection AddSwaggerGenExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAppBackend", Version = "v1" });
            });

            return services;
        }

        public static IServiceCollection AddServiceInjectionExtension(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, Services.Email.EmailService>();
            services.AddTransient<IAuthService, Services.Auth.AuthService>();
            services.AddTransient<IPostService, Services.PostService.PostService>();

            return services;
        }
    }
}
