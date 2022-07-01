﻿using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Services.ProfileService
{
    public class ProfileService : IProfileService
    {
        private readonly AutoMapper.IMapper mapper;
        private readonly DataContext context;

        public ProfileService(AutoMapper.IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ProfileViewModel> Get(int UserID, int id)
        {
            var result = await mapper.ProjectTo<ProfileViewModel>(
                                from p in context.Profiles
                                where p.UserID == UserID
                                select p, new { CurrentUserID = id })
                                .FirstOrDefaultAsync();
            return result;
        }

        public async Task Update(Profile profile, int UserID)
        {
            context.Profiles.Update(profile);
            await context.SaveChangesAsync();      
        }
    }
}
