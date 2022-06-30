namespace MyAppBackend.Services.GroupService
{
    interface IGroupService
    {
        dynamic SearchGroups(string param);
        dynamic SearchGroupUsers(int id, string param);
        dynamic GetGroupUsers(int id);
        dynamic GetGroupPosts(int id);
        dynamic GetGroupInfo(int id);
        dynamic UpdateGroupInfo(int id);
        dynamic DeleteGroup(int id);
        dynamic RemoveGroupUser(int id);
    }
}
