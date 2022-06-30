using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.Models;
using System;
using System.Linq;

namespace MyAppBackend.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly DataContext context;

        public GroupService(DataContext context)
        {
            this.context = context;
        }

        public dynamic SearchGroups(string param) 
        {
            throw new NotImplementedException();
        }

        public dynamic SearchGroupUsers(int id, string param)
        {
            throw new NotImplementedException();
        }

        public dynamic GetGroupUsers(int id)
        {
            throw new NotImplementedException();
        }

        public dynamic GetGroupPosts(int id)
        {
            throw new NotImplementedException();
        }

        public dynamic GetGroupInfo(int id)
        {
            throw new NotImplementedException();
        }

        public dynamic UpdateGroupInfo(Group body, int GroupID)
        {
            throw new NotImplementedException();
        }

        public void DeleteGroup(int GroupID)
        {
            var groupToDelete = context.Groups.Where(x => x.ID == GroupID).FirstOrDefault();

            if (groupToDelete != null)
            {
                context.Groups.Remove(groupToDelete);
                context.SaveChanges();
            }
        }

        public void RemoveGroupUser(int UserID, int GroupID)
        {
            var userToRemove = context.GroupMembers.Where(x => x.UserID == UserID && x.GroupID == GroupID).FirstOrDefault();

            if (userToRemove != null && userToRemove.RoleID != 3)
            {
                context.GroupMembers.Remove(userToRemove);
                context.SaveChanges();
            }
        }

        public Group CreateGroup(Group group, int UserID)
        {      
            context.Groups.Add(group);
            context.SaveChanges();

            var newMember = new GroupMember
            {
                GroupID = group.ID,
                UserID = UserID,
                RoleID = 3     
            };
            context.GroupMembers.Add(newMember);
            context.SaveChanges();

            return group;
        }

        public dynamic GetUserGroups(int UserID)
        {
            var result = context.Users
                .Include(x => x.Groups)
                .Where(x => x.ID == UserID)
                .Select(x => x.Groups.Select(x => new { x.Role.RoleName, x.Group }));

            return result;
        }

        public void GetRecommendedGroups(int UserID)
        {
            throw new NotImplementedException();
        }
    }
}
