using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using TESTEGARAGENS_DR_WEBAPI.Data;
using TESTEGARAGENS_DR_WEBAPI.Models;

namespace TESTEGARAGENS_DR_WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassagemController : ControllerBase
    {
        private readonly DAL _context;

        public PassagemController(DAL context){
            _context = context;
        }

        [HttpGet]  
        public IActionResult Get()
        {
            return Ok(_context.Passagens);
        }

        [HttpGet("{id}")]  
        public IActionResult GetById(int id)
        {
            var passagem = _context.Passagens.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if(passagem == null) return BadRequest("Registro não encontrado!!");
            return Ok(passagem);
        }

        [HttpPost]
        public IActionResult Post(Passagem passagens)
        {
            _context.Add(passagens);
            _context.SaveChanges();
            return Ok(passagens);
        }

        [HttpPut("{id}")] 
        public IActionResult Put(int id,Passagem passagens)
        {
            var passagem = _context.Passagens.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if(passagem == null) return BadRequest("Registro não encontrado!!");

            _context.Update(passagens);
            _context.SaveChanges();
            return Ok(_context.Passagens);
        }

        [HttpPatch("{id}")] 
        public IActionResult Patch(int id,Passagem passagens)
        {
            var passagem = _context.Passagens.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if(passagem == null) return BadRequest("Registro não encontrado!!");

            _context.Update(passagens);
            _context.SaveChanges();
            return Ok(_context.Passagens);
        }

        [HttpDelete("{id}")] 
        public IActionResult Delete(int id)
        {
            var passagem = _context.Passagens.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if(passagem == null) return BadRequest("Registro não encontrado!!");

            _context.Remove(passagem);
            return Ok();
        }
    }
}