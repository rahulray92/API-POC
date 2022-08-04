using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_POC.models
{
    public class Loan
    {   
        [Key]
        public long id { get; set; } 
        public string fname { get; set; } 
        public string lname { get; set; }  

        public long loanno{get;set;}
        public string loanterm { get; set; }
        public string loantype { get; set; }
        public string propertyaddress{get;set;}

        public User?User{get;set;}
    }
}