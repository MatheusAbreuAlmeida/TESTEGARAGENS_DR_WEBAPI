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
        private readonly IRepository _repo;
        public PassagemController(IRepository repo){
            _repo = repo;
        }

        [HttpGet]  
        public IActionResult Get()
        {
            var result = _repo.GetAllPassagens(false);
            return Ok(result);
        }

        [HttpGet("{id}")]  
        public IActionResult GetById(int id)
        {
            var passagem = _repo.GetAllPassagemById(id,false);
            if(passagem == null) return BadRequest("Registro não encontrado!!");
            return Ok(passagem);
        }

        [HttpPost]
        public IActionResult Post(Passagem passagens)
        {
            _repo.Add(passagens);
            if (_repo.SaveChanges())
            {
                return Ok(passagens);
            }

            return BadRequest("Erro no registro!");
        }

        [HttpPut("{id}")] 
        public IActionResult Put(int id,Passagem passagens)
        {
            var passagem = _repo.GetAllPassagemById(id,false);
            if(passagem == null) return BadRequest("Registro não encontrado!!");

            _repo.Update(passagens);
            if (_repo.SaveChanges())
            {
                return Ok(passagens);
            }

            return BadRequest("Registro não atualizado!");
        }

        [HttpPatch("{id}")] 
        public IActionResult Patch(int id,Passagem passagens)
        {
            var passagem = _repo.GetAllPassagemById(id,false);
            if(passagem == null) return BadRequest("Registro não encontrado!!");

            _repo.Update(passagens);
            if (_repo.SaveChanges())
            {
                return Ok(passagens);
            }

            return BadRequest("Registro não atualizado!");
        }

        [HttpDelete("{id}")] 
        public IActionResult Delete(int id)
        {
            var passagem = _repo.GetAllPassagemById(id,false);
            if(passagem == null) return BadRequest("Registro não encontrado!!");

            _repo.Delete(passagem);
            if (_repo.SaveChanges())
            {
                return Ok("Registro deletado!");
            }

            return BadRequest("Registro não deletado!");
        }
    }
}