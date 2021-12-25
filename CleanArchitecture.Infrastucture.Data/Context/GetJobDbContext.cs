
using CleanArchitecture.DomainCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastucture.Data.Context
{
    
        public class GetJobDbContext : DbContext
        {
            public GetJobDbContext(DbContextOptions<GetJobDbContext> options) : base(options) { }

            public DbSet<Students> Students { get; set; }
        }
    }

