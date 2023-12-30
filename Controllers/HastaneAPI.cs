using HastaneWeb.Data;
using HastaneWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HastaneWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastaneAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HastaneAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<HastaneAPI>
        [HttpGet]
        public List<Doktor> Get()
        {
            return _context.Doktorlar.ToList();
        }

        // GET api/<HastaneAPI>/5
        [HttpGet("{id}")]
        public ActionResult<Doktor> Get(int id)
        {
            var doktor = _context.Doktorlar.FirstOrDefault(x => x.DoktorID == id);
            if (doktor == null)
            {
                return NotFound();
            }
            return doktor;
        }

        // POST api/<HastaneAPI>
        [HttpPost]
        public void Post([FromBody] Doktor doktorFromApi)
        {
            var doktor = new Doktor
            {
                DoktorAd = doktorFromApi.DoktorAd,
                DoktorSoyad = doktorFromApi.DoktorSoyad,
                Poliklinik = doktorFromApi.Poliklinik,
            };
            _context.Doktorlar.Add(doktor);
            _context.SaveChanges();
        }

        // PUT api/<HastaneAPI>/5
        [HttpPut("{id}")]
        public ActionResult<Doktor> Put(int id, [FromBody] Doktor doktor)
        {
            var doktorFromDb = _context.Doktorlar.FirstOrDefault(x => x.DoktorID == id);
            if (doktorFromDb != null)
            {
                doktorFromDb.DoktorAd = doktor.DoktorAd;
                doktorFromDb.DoktorSoyad = doktor.DoktorSoyad;
                doktorFromDb.Poliklinik = doktor.Poliklinik;
                _context.SaveChanges();
            }
            return NotFound();
        }

        // DELETE api/<HastaneAPI>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
