using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_POC.DTOs.LoanDetails
{
    public class GetLoanDto
    {
                public string fname { get; set; } 
        public string lname { get; set; }  

        public long loanno{get;set;}
        public string loanterm { get; set; }
        public string loantype { get; set; }
        public string propertyaddress{get;set;}
    }
}