﻿using ApiProjectCampNew1.Context;
using ApiProjectCampNew1.Dtos.MessageDtos;
using ApiProjectCampNew1.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCampNew1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public MessagesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _context.Messages.ToList(); // listeyi getiriyo
            return Ok(_mapper.Map<List<ResultMessageDto>>(values)); // map edip dönüyor
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var Value = _mapper.Map<Message>(createMessageDto);
            _context.Messages.Add(Value);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı");
        }
        [HttpGet("GetMessage")]
        public IActionResult GetMessage(int id)
        {
            var message = _context.Messages.Find(id);
            return Ok(_mapper.Map<GetByIdMessageDto>(message));
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var message = _mapper.Map<Message>(updateMessageDto);
            _context.Messages.Update(message);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı");
        }
    }
}
