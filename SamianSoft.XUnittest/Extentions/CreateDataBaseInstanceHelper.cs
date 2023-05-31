using Microsoft.EntityFrameworkCore;
using SamianSoft.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamianSoft.XUnittest.Extentions
{
    public static class CreateDataBaseInstanceHelper
    {
        public static DbContextOptions<SFDbContext> CreateDbContextOption()
        {
            return new DbContextOptionsBuilder<SFDbContext>()
            .UseInMemoryDatabase(databaseName: "MyTestDatabase")
            .Options;
        }
    }
}
