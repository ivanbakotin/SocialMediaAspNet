using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.ViewModels
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
    }
}
