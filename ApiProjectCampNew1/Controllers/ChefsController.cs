using ApiProjectCampNew1.Context;
using ApiProjectCampNew1.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCampNew1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ChefsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet] // listeleme işlemleri için
        public IActionResult ChefList()
        {
            var values = _context.Chef.ToList();
            return Ok(values);
        }
        [HttpPost] // ekleme işlemleri için
        public IActionResult CreateChef(Chef chef)
        {
            _context.Chef.Add(chef);
            _context.SaveChanges();
            return Ok("Şef Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var value = _context.Chef.Find(id);
            _context.Chef.Remove(value);
            _context.SaveChanges();
            return Ok("Şef Silindi");
        }
        [HttpGet("GetChef")] // bir kez httpget kullanıldığı için haa verir bu listeleme için isim vermek gerekiyor
        public IActionResult GetChef(int id)
        {
            var value = _context.Chef.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
            _context.Chef.Update(chef);
            _context.SaveChanges();
            return Ok("Şef Güncellendi");
        }
    }
}
