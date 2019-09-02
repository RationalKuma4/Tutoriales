using Microsoft.EntityFrameworkCore;

namespace CoreMvc.Models
{
    public class AppDbConetxt : DbContext
    {
        public AppDbConetxt(DbContextOptions<AppDbConetxt> options)
            : base(options)
        {

        }

        public DbSet<Pie> Pies { get; set; }
    }
}
