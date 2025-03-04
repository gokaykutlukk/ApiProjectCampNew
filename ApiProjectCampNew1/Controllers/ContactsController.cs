using ApiProjectCampNew1.Context;
using ApiProjectCampNew1.Dtos.ContactDtos;
using ApiProjectCampNew1.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCampNew1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ContactsController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet] // listeleme işlemleri için
        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return Ok(values);
        }
        [HttpPost] // ekleme işlemleri için
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            Contact contact = new Contact();
            contact.Email = createContactDto.Email;
            contact.Adress = createContactDto.Adress;
            contact.MapLocation = createContactDto.MapLocation;
            contact.OpenHours = createContactDto.OpenHours;
            contact.Phone = createContactDto.Phone;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("İletişim Bilgisi Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok("İletişim Bilgisi Silindi");
        }
        [HttpGet("GetContact")] // bir kez httpget kullanıldığı için haa verir bu listeleme için isim vermek gerekiyor
        public IActionResult GetContact(int id)
        {
            var value = _context.Contacts.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact();
            contact.ContactId = updateContactDto.ContactId;
            contact.Email = updateContactDto.Email;
            contact.Adress = updateContactDto.Adress;
            contact.MapLocation = updateContactDto.MapLocation;
            contact.OpenHours = updateContactDto.OpenHours;
            contact.Phone = updateContactDto.Phone;
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("İletişim Bilgisi Güncellendi");
        }
    }
}
