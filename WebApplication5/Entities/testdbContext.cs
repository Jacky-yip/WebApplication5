using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Entities
{

    public class testdbContext : DbContext
    {
        public testdbContext(DbContextOptions<testdbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=3gxirdll;database=test");
            //}
        }
        public DbSet<tb1> tb1 { get; set; }
    }
}
