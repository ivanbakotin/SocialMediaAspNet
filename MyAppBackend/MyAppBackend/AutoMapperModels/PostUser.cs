using MyAppBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.AutoMapperModels
{
    public class PostUser
    {
        public Post Post { get; set; }
        public User User { get; set; }
    }
}
