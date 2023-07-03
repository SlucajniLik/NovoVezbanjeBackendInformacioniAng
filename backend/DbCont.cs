using backend.Modeli;
using Microsoft.EntityFrameworkCore;

namespace backend
{
    public class DbCont:DbContext
    {
        public DbCont(DbContextOptions<DbCont> options) : base(options) { }



        public DbSet<Radnik> radnik { get; set; }

       public DbSet<Poslovi> posao { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {





            modelBuilder.Entity<Radnik>().HasData(
                new List<Radnik>
                {
                    new Radnik{Id=1,IdPosla=1,Ime="Radnik1",Prezime="pre1",Lozinka="1"}
                    ,

                    new Radnik{Id=2,IdPosla=2,Ime="Radnik2",Prezime="pre2",Lozinka="1"}


               ,
                    new Radnik{Id=3,IdPosla=3,Ime="Radnik3",Prezime="pre3",Lozinka="1"}


                }


                );
            modelBuilder.Entity<Poslovi>().HasData(
               new List<Poslovi>
               {
                    new Poslovi{Id=1,Naziv="a"}

                  ,
            
                    new Poslovi {Id=2,Naziv="b"}


             ,
                    new Poslovi {Id=3,Naziv="c"}


               }


               );







            



            base.OnModelCreating(modelBuilder);







        }


    }
}
