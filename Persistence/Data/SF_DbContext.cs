using Microsoft.EntityFrameworkCore;
using SamianSoft.Domain.DataInterface;
using SamianSoft.Domain.Entity;

namespace SamianSoft.Persistence.Data
{
    public class SFDbContext : DbContext, ISF_DbContext
    {
        #region Consturcotr
        public SFDbContext(DbContextOptions<SFDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        #endregion

        #region Impeliment Entities
        public DbSet<ObjectTemplate> ObjectTemplates { get; set; }
        #endregion

        #region Methods
        public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();
        #endregion

        #region OvverRides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AF7P9D7;Database=SamianSoftTemplate;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
