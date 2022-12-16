using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace UserLevels
{
    public class ApplicationDatabaseContext : DbContext
    {
        private readonly DbContextOptions _options;

        public ApplicationDatabaseContext(DbContextOptions options) : base(options)
        {
            //we added this builder to solve an exception
            _options = options;

        }

        public DbSet<Cube> Cubes { get; set; }

        public DbSet<CubeList> CubeLists { get; set; }

    }
}
