using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public GroupService(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<Group>> SearchGroups(string param) 
        {
            return await context.Groups.Where(x => x.Name.Contains(param)).ToListAsync();
        }

        public async Task<dynamic> SearchGroupUsers(int GroupID, string param)
        {
            var result = await context.Groups
                            .Where(x => x.ID == GroupID)
                            .Select(x => x.Members
                            .Select(x => new User { Username = x.User.Username, ID = x.User.ID}))
                            .ToListAsync();
            return result;
        }

        public async Task<List<GroupMember>> GetGroupUsers(int GroupID)
        {
            var groupMembers = await context.GroupMembers.Where(x => x.GroupID == GroupID).ToListAsync();
            return groupMembers;
        }

        public async Task<List<Post>> GetGroupPosts(int GroupID)
        {
            var groupPosts = await context.Posts.Where(x => x.GroupID == GroupID).ToListAsync();
            return groupPosts;
        }

        public async Task<Group> GetGroupInfo(int GroupID)
        {
            var group = await context.Groups.Where(x => x.ID == GroupID).FirstOrDefaultAsync();
            return group;
        }

        public async Task UpdateGroupInfo(Group body, int GroupID, int UserID)
        {
            var isOwnerOrAdmin = context.GroupMembers.Any(x => x.GroupID == GroupID && x.UserID == UserID && (x.RoleID == 3 || x.RoleID == 1));

            if (isOwnerOrAdmin)
            {
                var groupToUpdate = await context.Groups.Where(x => x.ID == GroupID).FirstOrDefaultAsync();

                if (groupToUpdate != null)
                {
                    groupToUpdate.Description = body.Description;
                };

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteGroup(int GroupID, int UserID)
        {
            var isOwner = context.GroupMembers.Any(x => x.GroupID == GroupID && x.RoleID == 3 && x.UserID == UserID);
            
            if (isOwner) 
            {
                var groupToDelete = await context.Groups.Where(x => x.ID == GroupID).FirstOrDefaultAsync();

                if (groupToDelete != null)
                {
                    context.Groups.Remove(groupToDelete);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task RemoveGroupUser(int UserID, int GroupID)
        {
            var isOwnerOrAdmin = context.GroupMembers.Any(x => x.GroupID == GroupID && x.UserID == UserID &&  (x.RoleID == 3 || x.RoleID == 1));

            if (isOwnerOrAdmin)
            {
                var userToRemove = await context.GroupMembers.Where(x => x.UserID == UserID && x.GroupID == GroupID && !(x.RoleID == 3)).FirstOrDefaultAsync();

                if (userToRemove != null && userToRemove.RoleID != 3)
                {
                    context.GroupMembers.Remove(userToRemove);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<GroupViewModel> CreateGroup(Group group, int UserID)
        {
            await context.Groups.AddAsync(group);
            await context.SaveChangesAsync();

            var newMember = new GroupMember
            {
                GroupID = group.ID,
                UserID = UserID,
                RoleID = 3     
            };
            await context.GroupMembers.AddAsync(newMember);
            await context.SaveChangesAsync();

            GroupViewModel newGroup = mapper.Map<GroupViewModel>(newMember);
            newGroup.Role = "owner";

            return newGroup;
        }

        public async Task<List<IEnumerable<GroupViewModel>>> GetUserGroups(int UserID)
        {
            var result = await context.Users
                                        .Where(x => x.ID == UserID)
                                        .Select(x => x.Groups
                                        .Select(x => 
                                            new GroupViewModel {                                       
                                                Role = x.Role.RoleName,
                                                Name = x.Group.Name,
                                                Description = x.Group.Description,
                                                ID = x.Group.ID,
                                                MembersNumber = x.Group.Members.Count()
                                         })).ToListAsync();

            return result;
        }

        public Task<List<Group>> GetRecommendedGroups(int UserID)
        {
            throw new NotImplementedException();
        }
    }
}
