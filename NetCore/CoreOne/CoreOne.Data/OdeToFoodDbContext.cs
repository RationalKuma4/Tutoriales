using System;
using System.Collections.Generic;
using System.Text;
using CoreOne.Core;
using Microsoft.EntityFrameworkCore;

namespace CoreOne.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options): base(options)
        {

        }

        public DbSet<Restaunrant> Restaunrants { get; set; }
    }
}
