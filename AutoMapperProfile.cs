using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_POC.DTOs.LoanDetails;
using API_POC.models;
using AutoMapper;

namespace API_POC
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Loan,GetLoanDto>();
            CreateMap<AddLoanDto,Loan>();
        }
    }
}