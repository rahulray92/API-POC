using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_POC.DTOs.LoanDetails;
using API_POC.models;

namespace API_POC.Services.loanDetails
{
    public interface ILoanService
    {
        Task<ServiceResponse<List<GetLoanDto>>> GetLoanDetails();
       
        Task<ServiceResponse<GetLoanDto>> GetSingleLoanDetails(long loanno);
        Task<ServiceResponse<List<GetLoanDto>>> AddLoanDetails(AddLoanDto newloan);
        Task<ServiceResponse<GetLoanDto>> UpdateLoan(UpdateLoanDto updateLoan);
         Task<ServiceResponse<List<GetLoanDto>>> DeleteLoan(long loanno);
    }
}