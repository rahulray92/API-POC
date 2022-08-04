using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_POC.Data;
using API_POC.DTOs.LoanDetails;
using API_POC.models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_POC.Services.loanDetails
{
    public class LoanService : ILoanService
    {
        private static List<Loan> loanDetials=new List<Loan>{
new Loan {fname="Rahul",lname="Ray",loanno=243456,propertyaddress="pune",loanterm="24 Months",loantype="Homeloan"}
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public LoanService(IMapper mapper,DataContext context){
            _mapper = mapper;
            _context = context;
        }

       

        public async Task<ServiceResponse<List<GetLoanDto>>> GetLoanDetails()
        {
           var serviceResponse=new ServiceResponse<List<GetLoanDto>>();
           var dbloan= await _context.Loans.ToListAsync();
           serviceResponse.Data=dbloan.Select(c=>_mapper.Map<GetLoanDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLoanDto>> GetSingleLoanDetails(long loanno)
        {
            var serviceResponse=new ServiceResponse<GetLoanDto>();
            var loandata=loanDetials.FirstOrDefault(x=>x.loanno==loanno);
            serviceResponse.Data=_mapper.Map<GetLoanDto>(loandata);
            return serviceResponse;
        }
       public async Task<ServiceResponse<List<GetLoanDto>>> AddLoanDetails(AddLoanDto newloan)
        {
             var serviceResponse=new ServiceResponse<List<GetLoanDto>>();
           Loan loan= _mapper.Map<Loan>(newloan);
           _context.Loans.Add(loan);
           await _context.SaveChangesAsync();
            serviceResponse.Data= await _context.Loans.Select(c=>_mapper.Map<GetLoanDto>(c)).ToListAsync();
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetLoanDto>> UpdateLoan(UpdateLoanDto updateloan)
        {
             var serviceResponse=new ServiceResponse<GetLoanDto>();
             try
             {
                
             
             Loan loandata=loanDetials.FirstOrDefault(x=>x.loanno==updateloan.loanno);
             loandata.fname=updateloan.fname;
             loandata.lname=updateloan.lname;
             loandata.loanterm=updateloan.loanterm;
             loandata.loantype=updateloan.loantype;
             loandata.propertyaddress=updateloan.propertyaddress;  

             await _context.SaveChangesAsync();          
            serviceResponse.Data=_mapper.Map<GetLoanDto>(loandata);
            }
             catch (Exception ex)
             {
                
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
             }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetLoanDto>>> DeleteLoan(long loanno)
        {
            var serviceResponse=new ServiceResponse<List<GetLoanDto>>();
             try
             {
                
             
             Loan loandata= await _context.Loans.FirstAsync(x=>x.loanno==loanno);
                _context.Loans.Remove(loandata);  
                await _context.SaveChangesAsync();     
            serviceResponse.Data=_context.Loans.Select(x=>_mapper.Map<GetLoanDto>(x)).ToList();
            }
             catch (Exception ex)
             {
                
                serviceResponse.Success=false;
                serviceResponse.Message=ex.Message;
             }
            return serviceResponse;
        }
    }
}