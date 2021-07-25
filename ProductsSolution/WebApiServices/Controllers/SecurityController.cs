﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Entities;
using IBusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private ISecurityBL securityBL;

        public SecurityController(ISecurityBL _securityBL)
        {
            this.securityBL = _securityBL;
        }

        [HttpGet("GetAllUsers")]
        public IList<UserDTO> GetAllUsers()
        {
            return this.securityBL.GetAllUserDtos();
        }

    }
}