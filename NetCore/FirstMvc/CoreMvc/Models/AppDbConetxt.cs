using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreMvc.Models
{
    public class AppDbConetxt : IdentityDbContext<IdentityUser>
    {
        public AppDbConetxt(DbContextOptions<AppDbConetxt> options)
            : base(options)
        {

        }

        public DbSet<Pie> Pies { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
