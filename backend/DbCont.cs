using backend.Modeli;
using Microsoft.EntityFrameworkCore;

namespace backend
{
    public class DbCont:DbContext
    {
        public DbCont(DbContextOptions<DbCont> options) : base(options) { }



        public DbSet<Radnik> radnik { get; set; }

       public DbSet<Poslovi> posao { get; set; }


    }
}
