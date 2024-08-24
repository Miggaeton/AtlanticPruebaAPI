using AtlanticPruebaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AtlanticPruebaAPI.Context
{
    public class InsuredContext : DbContext
    {
        public InsuredContext(DbContextOptions<InsuredContext> options) : base(options)
        {
        }

        public DbSet<InsuredModel> Insured { get; set; }
    }
}
