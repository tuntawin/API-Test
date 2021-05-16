using API_Test.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.Services.Tests
{
    public class TestContext : IDisposable
    {
        protected IDbContextTransaction Transaction { get; }
        protected NORTHWNDContext DbContext { get; }

        public TestContext()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            // configure our database
            var connection = configuration.GetConnectionString("ConnectionString");
            var options = new DbContextOptionsBuilder<NORTHWNDContext>()
                .UseSqlServer(connection)
                .Options;

            DbContext = new NORTHWNDContext(options);

            // begin the transaction
            Transaction = DbContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            //Clean up
            DbContext.Dispose();

            //Rollback 
            if (Transaction != null)
            {
                Transaction.Rollback();
                Transaction.Dispose();
            }
        }
    }
}
