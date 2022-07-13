using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.Repositories;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Services.FriendService
{
    public class FriendService : IFriendService
    {
        private readonly IUnitOfWork unitOfWork;

        public FriendService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserViewModel>> GetAllRequestsPending(int UserID)
        {
            return await unitOfWork.FriendRequests.GetAllRequestsPending(UserID);
        }

        public async Task<IEnumerable<UserViewModel>> GetAllRequestsSent(int UserID)
        {
            return await unitOfWork.FriendRequests.GetAllRequestsSent(UserID);
        }

        public async Task<IEnumerable<Friend>> GetAllFriends(int id)
        {
            return await unitOfWork.Friends.GetAllFriends(id);
        }

        public void SendFriendRequest(int UserID, int id) 
        {
            FriendRequest newFriendRequest = new()
            {
                UserID = id,
                FollowerID = UserID
            };

            unitOfWork.FriendRequests.Add(newFriendRequest);
            unitOfWork.Save();
        }

        public async Task RemoveFriend(int UserID, int id)
        {
            var toDeleteFriend = await unitOfWork.Friends.Find(f => (f.UserID2 == UserID && f.UserID1 == id)
                                                                 || (f.UserID1 == UserID && f.UserID2 == id));

            if (toDeleteFriend != null)
            {
                unitOfWork.Friends.Remove(toDeleteFriend);
                unitOfWork.Save();
            }
        }

        public async Task AcceptFriendRequest(int UserID, int id)
        {
            var toDeleteRequest = await unitOfWork.FriendRequests.Find(f => ((f.UserID == UserID && f.FollowerID == id)
                                                                          || (f.FollowerID == UserID && f.UserID == id)));

            if (toDeleteRequest != null)
            {
                unitOfWork.FriendRequests.Remove(toDeleteRequest);
            }

            var newFriend = new Friend
            {
                UserID1 = id,
                UserID2 = UserID
            };

            unitOfWork.Friends.Add(newFriend);
            unitOfWork.Save();
        }

        public async Task RemoveFriendRequest(int UserID, int id)
        {
            var toDeleteRequest = await unitOfWork.FriendRequests.Find(f => ((f.UserID == UserID && f.FollowerID == id)
                                                                          || (f.FollowerID == UserID && f.UserID == id)));

            if (toDeleteRequest != null)
            {
                unitOfWork.FriendRequests.Remove(toDeleteRequest);
                unitOfWork.Save();
            }
        }
    }
}
