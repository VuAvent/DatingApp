using System.Collections.Generic;
using DatingApp.API.Database.Entities;
using DatingApp.API.DTOs;

namespace DatingApp.API.Database.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        IEnumerable<MemberDto> GetMembers();
        User GetUserByUsername(string username);
        User GetUserById(int id);
        MemberDto  GetMemberByUsername(string username);
        void CreateUser(User user);
        bool SaveChanges();
    }
}