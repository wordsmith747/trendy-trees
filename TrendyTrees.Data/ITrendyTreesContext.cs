using Microsoft.EntityFrameworkCore;

namespace TrendyTrees.Data
{
    public interface ITrendyTreesContext
    {
        public DbSet<CustomerInquiry> CustomerInquiries { get; set; }

        int SaveChanges();
    }
}