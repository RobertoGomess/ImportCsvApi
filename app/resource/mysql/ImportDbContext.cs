
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ImportCsv.app.resource.mysql.models;

namespace ImportCsv.app.resource.mysql
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