using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_POC.DTOs.User
{
    public class UserLoginDto
    {
         public string UserName { get; set; }=string.Empty;
        public string Password{get;set;}=string.Empty;
    }
}