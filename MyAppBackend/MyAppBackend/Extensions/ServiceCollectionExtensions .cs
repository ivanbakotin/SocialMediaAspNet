﻿using Microsoft.Extensions.DependencyInjection;
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
using MyAppBackend.Services.FriendService;
using MyAppBackend.Services.UserService;
using MyAppBackend.Services.ProfileService;
using MyAppBackend.Services.CommentService;
using MyAppBackend.Services.GroupService;
using MyAppBackend.Services.GroupRequestService;
using MyAppBackend.ActionFilters;
using MyAppBackend.Repositories;
using MyAppBackend.Repositories.PostRepositories;

namespace MyAppBackend.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddJwtAuthenticationExtension(this IServiceCollection services)
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
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Yh2k7QSu4l8CZg5p6X3Pna9L0Miy4D3Bvt0JVr87UcOj69Kqw5R2Nmf4FWs03Hdx"))
            };
            });

            return services;
        }

        public static IServiceCollection AddCorsExtension(this IServiceCollection services)
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

        public static IServiceCollection AddEmailExtension(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSingleton(
                Configuration
                    .GetSection("EmailConfiguration")
                    .Get<ResetEmail>()
            );

            return services;
        }

        public static IServiceCollection AddDbContextExtension(this IServiceCollection services)
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
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IFriendService, FriendService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IGroupRequestService, GroupRequestService>();
            services.AddTransient<IGroupService, GroupService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            services.AddScoped<PasswordFilter>();
            services.AddScoped<GroupOwnerAdminFilter>();
            services.AddScoped<GroupOwnerFilter>();
            services.AddScoped<MemberFilter>();
            services.AddScoped<PostOwnerFilter>();

            return services;
        }
    }

    internal class T { }
}
