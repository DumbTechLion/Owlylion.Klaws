using Microsoft.EntityFrameworkCore;
using Owlylion.Klaws.Test.DataAccessLayer.EfCore.Models;

namespace Owlylion.Klaws.Test.DataAccessLayer.EfCore
{
    public class LionDbContext : DbContext
    {
        public DbSet<LionEntity> Lions { get; set; }
        public DbSet<PackEntity> Packs { get; set; }
    }
}
