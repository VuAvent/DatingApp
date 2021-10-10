using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingApp.API.Database.Entities;
using DatingApp.API.DTOs;
using Namespace;

namespace DatingApp.API.Database.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

           public UserRepository(DataContext context,  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        } 
        public void CreateUser(User user)
        {
           if(GetUserByUsername(user.Username) != null) return;
           _context.Users.Add(user);
           throw new System.NotImplementedException();

        }

        public MemberDto GetMemberByUsername(string username)
        {
            return _context.Users
                .Where(u => u.Username == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .FirstOrDefault();
        }

        public IEnumerable<MemberDto> GetMembers()
        {
            return _context.Users.ProjectTo<MemberDto>(_mapper.ConfigurationProvider);
            
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}