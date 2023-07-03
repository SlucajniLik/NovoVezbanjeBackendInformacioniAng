using backend.Modeli;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace backend.Controllers
{
    public class RadnikController : ControllerBase
    {
        private readonly DbCont db;
        public RadnikController(DbCont  db)
        {
            this.db = db;
        }



        [HttpPost("addRadnik")]
        public async Task<IActionResult>addRadnik([FromBody]Radnik radnik)
        {

            await this.db.radnik.AddAsync(radnik);  

            await this.db.SaveChangesAsync();   

           return Ok(radnik);
        }


        [HttpGet("getRadnike")]
        public async Task<IActionResult> getRadnike()
        {

          var radnici=  await this.db.radnik.ToListAsync();

           
            return Ok(radnici);
        }

        [HttpGet("getRadnik/{id}")]
        public async Task<IActionResult> getRadnik(int id)
        {

            var radnici = await this.db.radnik.FirstOrDefaultAsync(t=>t.Id==id);


            return Ok(radnici);
        }

        [HttpPut("updateRadnik/{id}")]
        public async Task<IActionResult> updateRadnik(int id, [FromBody]Radnik radnik2)
        {

            var radnik= await this.db.radnik.FirstOrDefaultAsync(t => t.Id == id);
            radnik.Ime = radnik2.Ime;
            radnik.Prezime= radnik2.Prezime;
            radnik.Lozinka= radnik2.Lozinka;    

            db.radnik.Update(radnik);
           await  this.db.SaveChangesAsync();
            return Ok(radnik);
        }

        [HttpDelete("deleteRadnik/{id}")]
        public async Task<IActionResult> deleteRadnik(int id)
        {

            var radnik = await this.db.radnik.FirstOrDefaultAsync(t => t.Id == id);
           


            db.radnik.Remove(radnik);   
            await this.db.SaveChangesAsync();
            return Ok();
        }


        [HttpPost("addPosao")]
        public async Task<IActionResult> addPosao([FromBody] Poslovi posao)
        {

            await this.db.posao.AddAsync(posao);

            await this.db.SaveChangesAsync();

            return Ok(posao);
        }


        [HttpGet("getPosao")]
        public async Task<IActionResult> getPosao()
        {

            var poslovi = await this.db.posao.ToListAsync();


            return Ok(poslovi);
        }




        [HttpGet("getRadnikPosao")]
        public async Task<IActionResult> getRadnikPosao()
        {

            var radnici = await (from a in db.radnik 
                                 join b in db.posao
                                 on a.IdPosla equals b.Id
                                 select new
                                 {
                                  id=a.Id,
                                  ime= a.Ime,
                                  prezime=a.Prezime,
                                  lozinka=a.Lozinka,
                                  naziv=b.Naziv

                                 }
                                 ).ToListAsync();


            return Ok(radnici);
        }


        public class logIn
        {

            public string ime { get; set; }
            }

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] logIn  obj)
        {

            var radnik = await this.db.radnik.FirstOrDefaultAsync(t => t.Ime == obj.ime);


        if(radnik==null)
            {
                // return BadRequest(new {msg="korisnik nije registrovan"});
                return Ok(new { msg = "korisnik nije registrovan" });
            }


            return Ok(radnik);




        }


        [HttpGet("getMax")]
        public async Task<IActionResult> getMax()
        {

            var max = this.db.radnik.Max(e => e.Id);


            return Ok(max);
        }





    }
}
