
using ImportCsv.Api.Resources.Mysql.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ImportCsv.Api.Resources.Mysql
{
    public class ImportDbContext : DbContext
    {
        public ImportDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public DbSet<Price> Prices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}