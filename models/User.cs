using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_POC.models
{
    public class User
    {
        public int Id { get; set; }
         public string UserName{ get; set; }=string.Empty;
          public byte[] PasswordHash { get; set; }
           public byte[] PasswordSalt { get; set; }
           public List<Loan>? Loans{get;set;}
    }
}