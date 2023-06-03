using Microsoft.EntityFrameworkCore;
using SamianSoft.Persistence.Data;

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
