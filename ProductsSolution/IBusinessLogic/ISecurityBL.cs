using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace IBusinessLogic
{
    public interface ISecurityBL
    {
        IList<LoginModel> GetAllUsers();
        LoginModel GetUserByUserName(string username);

        IList<UserDTO> GetAllUserDtos();

    }
}
