using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_POC.DTOs.LoanDetails;
using API_POC.models;
using API_POC.Services.loanDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_POC.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController:ControllerBase
    {
        private readonly ILoanService _loanService ;
        public LoanController(ILoanService loanService)
        {
            _loanService = loanService;

        }
        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetLoanDto>>>> GetLoanDetails()
        {
            
            return Ok(await _loanService.GetLoanDetails());
        }
        [HttpGet("{loanno}")]
        public async Task<ActionResult<ServiceResponse<GetLoanDto>>> GetSingleLoanDetails(long loanno)
        {
            
            return Ok(await _loanService.GetSingleLoanDetails(loanno));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetLoanDto>>>> AddLoanDetails(AddLoanDto newloan)
        {
            
            return Ok(await _loanService.AddLoanDetails(newloan) );
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetLoanDto>>> UpdateLoan(UpdateLoanDto updateloan)
        {
            var response=await _loanService.UpdateLoan(updateloan);
            if(response.Data==null)
            {
                return NotFound(response);
            }
            return Ok(await _loanService.UpdateLoan(updateloan) );
        }
        [HttpDelete("{loanno}")]
        public async Task<ActionResult<ServiceResponse<GetLoanDto>>> DeleteLoan(long loanno)
        {
            
             var response=await _loanService.DeleteLoan(loanno);
            if(response.Data==null)
            {
                return NotFound(response);
            }
            return Ok(await _loanService.DeleteLoan(loanno) );
        }
    }
}