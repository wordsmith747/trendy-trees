using Microsoft.EntityFrameworkCore;

namespace TrendyTrees.Data
{
    public class TrendyTreesContext : DbContext, ITrendyTreesContext
    {
        public DbSet<CustomerInquiry> CustomerInquiries { get; set; }

        public TrendyTreesContext()
        {
        }

        public TrendyTreesContext(DbContextOptions<TrendyTreesContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
          {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=.;Initial Catalog=TrendyTrees;Integrated Security=True;");
            }
        }
    }
}