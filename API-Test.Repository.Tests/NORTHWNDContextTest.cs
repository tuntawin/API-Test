using API_Test.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Test.Repository.Tests
{
    public class NORTHWNDContextTest
    {
        protected IDbContextTransaction Transaction { get; }
        protected NORTHWNDContext DbContext { get; }

        public NORTHWNDContextTest()
        {
            // configure our database
            var options = new DbContextOptionsBuilder<NORTHWNDContext>()
                .UseSqlServer("Server=TEERAPONG\\SQLSERVER2014;Database=NORTHWND_UT;User Id=oceaweb;Password=oceaweb;")
                .Options;

            DbContext = new NORTHWNDContext(options);

            // begin the transaction
            Transaction = DbContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
                Transaction.Dispose();
            }
        }
    }
}
