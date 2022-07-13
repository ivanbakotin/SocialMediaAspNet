using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories.GroupRepositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(DataContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<IEnumerable<User>> SearchGroupUsers(int GroupID, string param)
        {
            return await context.Groups
                            .Where(x => x.ID == GroupID)
                            .SelectMany(x => x.Members
                            .Where(x => x.User.Username.Contains(param))
                            .Select(x => new User { Username = x.User.Username, ID = x.User.ID }))
                            .ToListAsync();
        }

        public async Task<IEnumerable<PostViewModel>> GetGroupPosts(int GroupID, int UserID)
        {
            return await mapper.ProjectTo<PostViewModel>(from post in context.Posts
                                                         where post.GroupID == GroupID
                                                         orderby post.ID descending
                                                         select post, new { CurrentUserID = UserID }).ToListAsync();
        }

        public async Task<IEnumerable<GroupViewModel>> GetUserGroups(int UserID)
        {
            return await context.Users
                            .Where(x => x.ID == UserID)
                            .SelectMany(x => x.Groups
                            .Select(x =>
                                new GroupViewModel
                                {
                                    Role = x.Role.Name,
                                    Name = x.Group.Name,
                                    Description = x.Group.Description,
                                    ID = x.Group.ID,
                                    MembersNumber = x.Group.Members.Count
                                })).ToListAsync();
        }
    }
}
