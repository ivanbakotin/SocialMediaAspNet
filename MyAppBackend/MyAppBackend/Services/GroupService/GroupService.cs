using AutoMapper;
using MyAppBackend.Models;
using MyAppBackend.Repositories;
using MyAppBackend.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Services.GroupService
{
    public class GroupService : IGroupService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GroupService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Group>> SearchGroups(string param) 
        {
            return await unitOfWork.Groups.FindAll(x => x.Name.Contains(param));
        }

        public async Task<IEnumerable<User>> SearchGroupUsers(int GroupID, string param)
        {
            return await unitOfWork.Groups.SearchGroupUsers(GroupID, param);
        }

        public async Task<IEnumerable<GroupMember>> GetGroupUsers(int GroupID)
        {
            return await unitOfWork.GroupMembers.FindAll(x => x.GroupID == GroupID);
        }

        public async Task<IEnumerable<PostViewModel>> GetGroupPosts(int GroupID, int UserID)
        {
            return await unitOfWork.Groups.GetGroupPosts(GroupID, UserID);
        }

        public PostViewModel CreateGroupPost(Post post, int UserID)
        {
            post.UserID = UserID;
            unitOfWork.Posts.Add(post);
            unitOfWork.Save();
            return mapper.Map<PostViewModel>(post);
        }

        public async Task<Group> GetGroupInfo(int GroupID)
        {
            return await unitOfWork.Groups.Find(x => x.ID == GroupID);
        }

        public async Task UpdateGroupInfo(Group body, int GroupID, int UserID)
        {
            var groupToUpdate = await unitOfWork.Groups.Find(x => x.ID == GroupID);

            if (groupToUpdate != null)
            {
                groupToUpdate.Description = body.Description;
                unitOfWork.Save();         
            };
        }

        public async Task DeleteGroup(int GroupID, int UserID)
        { 
            var groupToDelete = await unitOfWork.Groups.Find(x => x.ID == GroupID);

            if (groupToDelete != null)
            {
                var membersToDelete = await unitOfWork.GroupMembers.FindAll(x => x.GroupID == GroupID);
                unitOfWork.GroupMembers.RemoveRange(membersToDelete);
                unitOfWork.Groups.Remove(groupToDelete);
                unitOfWork.Save();
            }         
        }

        public async Task RemoveGroupUser(int UserID, int GroupID)
        {
            var userToRemove = await unitOfWork.GroupMembers.Find(x => x.UserID == UserID && x.GroupID == GroupID && !(x.RoleID == 3));

            if (userToRemove != null)
            {
                unitOfWork.GroupMembers.Remove(userToRemove);
                unitOfWork.Save();
            }      
        }

        public GroupViewModel CreateGroup(Group group, int UserID)
        {
            unitOfWork.Groups.Add(group);
            unitOfWork.Save();

            var newMember = new GroupMember
            {
                GroupID = group.ID,
                UserID = UserID,
                RoleID = 3     
            };
            unitOfWork.GroupMembers.Add(newMember);
            unitOfWork.Save();

            GroupViewModel newGroup = mapper.Map<GroupViewModel>(newMember);
            newGroup.Role = "owner";
            return newGroup;
        }

        public async Task<IEnumerable<GroupViewModel>> GetUserGroups(int UserID)
        {
            return await unitOfWork.Groups.GetUserGroups(UserID);
        }

        public Task<List<Group>> GetRecommendedGroups(int UserID)
        {
            throw new NotImplementedException();
        }
    }
}
