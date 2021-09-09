using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assessment2_WebAPI.Models;

namespace Assessment2_WebAPI.Data
{
    public class Assessment2_WebAPIContext : DbContext
    {
        public Assessment2_WebAPIContext (DbContextOptions<Assessment2_WebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Assessment2_WebAPI.Models.Customer_User> Customer_User { get; set; }

        public DbSet<Assessment2_WebAPI.Models.Rent_Agent> Rent_Agent { get; set; }

        public DbSet<Assessment2_WebAPI.Models.Rent_Houses> Rent_Houses { get; set; }

        public DbSet<Assessment2_WebAPI.Models.Rent_Details> Rent_Details { get; set; }
    }
}
