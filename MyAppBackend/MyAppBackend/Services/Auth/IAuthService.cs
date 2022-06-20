﻿using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Data;
using MyAppBackend.Models;

namespace MyAppBackend.Services.Auth
{
    public interface IAuthService
    {
        string Login(User user, DataContext context);
        Task Register(User user, DataContext context);
    }
}
