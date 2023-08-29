using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;

namespace DoranOfficeBackend
{
    public class MigrationContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            var mysqlConn = builder.Build().GetSection("ConnectionStrings:DefaultConnection").Value;
            optionsBuilder.UseMySQL(mysqlConn, opts => opts.CommandTimeout(800));
            return new MyDbContext(optionsBuilder.Options, true);
        }
    }
}