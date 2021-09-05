using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using Entities;
using IBusinessLogic;
using IRepositories;

namespace BusinessLogic
{
    public class SecurityBL: ISecurityBL
    {
        private IRepository<User> userRepository;
        public SecurityBL(IRepository<User> userRepository)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public IList<LoginModel> GetAllUsers()
        {
            var returnlist = new List<LoginModel>();
            var userList = this.userRepository.GetAll();
            foreach (var user in userList)
            {
                returnlist.Add(new LoginModel()
                {
                    UserName = user.UserName,
                    Password = user.Password
                });
            }

            return returnlist;
        }

        public LoginModel GetUserByUserName(string username)
        {
            var query = this.userRepository.GetQuery();
            var user = query.FirstOrDefault(x => x.UserName == username);
            if (user != null)
                return new LoginModel()
                {
                    UserName = user.UserName,
                    Password = user.Password
                };
            return null;
        }

        public IList<UserDTO> GetAllUserDtos()
        {
            var returnlist = new List<UserDTO>();
            var userList = this.userRepository.GetAll();
            foreach (var user in userList)
            {
                returnlist.Add(new UserDTO()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Password = user.Password
                });
            }

            return returnlist;
        }
    }
}
