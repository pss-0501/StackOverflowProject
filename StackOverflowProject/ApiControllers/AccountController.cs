using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StackOverflowProject.ServiceLayer;
using StackOverflowProject.ViewModels;

namespace StackOverflowProject.ApiControllers
{
    public class AccountController : ApiController
    {
        IUserService us;

        public AccountController(IUserService us)
        {
            this.us = us;
        }

        [HttpGet]
        public string Get(string Email)
        {
            if(this.us.GetUsersByEmail(Email) != null)
            {
                return "Found";
            }
            else
            {
                return "Not Found";
            }
        }
    }
}
