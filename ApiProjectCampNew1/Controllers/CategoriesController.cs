using ApiProjectCampNew1.Context;
using ApiProjectCampNew1.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCampNew1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;

        public CategoriesController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet] // listeleme işlemleri için
        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }
        [HttpPost] // ekleme işlemleri için
        public IActionResult CreateCategory(Category category)
        
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Kategori Eklendi");
        }
        [HttpDelete]
         
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Kategori Silindi");

        }

        [HttpGet("GetCategory")] // bir kez httpget kullanıldığı için haa verir bu listeleme için isim vermek gerekiyor
        public IActionResult GetCategory (int id)
        {
            var value = _context.Categories.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCategory (Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Kategori Güncellendi");
        }
    }
}
