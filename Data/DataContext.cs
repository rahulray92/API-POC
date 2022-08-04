using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace API_POC.Data
{
    public class DataContext :DbContext
    {
        public  DataContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Loan> Loans{get;set;}
        public DbSet<User> Users{get;set;}
        
    }
}