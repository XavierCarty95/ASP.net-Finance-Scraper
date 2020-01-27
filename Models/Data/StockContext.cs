using System;
using Microsoft.EntityFrameworkCore;
namespace Portfolio.Models.Data
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options)
            : base(options)
        {
        }

        public DbSet<Stocks> Stock { get; set; }
    }
}
