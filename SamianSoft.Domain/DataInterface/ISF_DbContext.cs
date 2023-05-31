using Microsoft.EntityFrameworkCore;
using SamianSoft.Domain.Entity;

namespace SamianSoft.Domain.DataInterface
{
    public interface ISF_DbContext:IDisposable
    {
        DbSet<ObjectTemplate> ObjectTemplates { get; set; }

        Task<int> SaveChangesAsync();
    }
}
