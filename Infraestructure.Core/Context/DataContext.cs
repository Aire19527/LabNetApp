using Infraestructure.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Core.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<SkillEntity> SkillEntity { get; set; }
    }
}
