using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using TESTEGARAGENS_DR_WEBAPI.Data;
using TESTEGARAGENS_DR_WEBAPI.Dtos;
using TESTEGARAGENS_DR_WEBAPI.Models;

namespace TESTEGARAGENS_DR_WEBAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PassagemController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public PassagemController(IRepository repo, IMapper mapper){
            _repo = repo;
            _mapper = mapper;
        }
        /// <summary>
        /// Metodo responsavel por retornar todos os registros de passagens
        /// </summary>
        /// <returns></returns>
        [HttpGet]  
        public IActionResult Get()
        {
            var result = _repo.GetAllPassagens(false);
            return Ok(_mapper.Map<IEnumerable<PassagemDTO>>(result));
        }
        /// <summary>
        /// Metodo responsavel por retornar o registro da passagem a partir do codigo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]  
        public IActionResult GetById(int id)
        {
            var passagem = _repo.GetAllPassagemById(id,false);
            if(passagem == null) return BadRequest("Registro não encontrado!!");

            var passagemDto =_mapper.Map<PassagemDTO>(passagem);

            return Ok(passagemDto);
        }

        [HttpPost]
        public IActionResult Post(PassagemDTO model)
        {
             var passagem = _mapper.Map<Passagem>(model);
             passagem.DataHoraEntrada = DateTime.Parse(model.DataHoraEntrada);
             passagem.DataHoraSaida = DateTime.Parse(model.DataHoraSaida);

            _repo.Add(passagem);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<PassagemDTO>(passagem));
            }

            return BadRequest("Erro no registro!");
        }

        [HttpPut("{id}")] 
        public IActionResult Put(int id,PassagemDTO model)
        {
            var passagem = _repo.GetAllPassagemById(id,false);
            if(passagem == null) return BadRequest("Registro não encontrado!!");

            _mapper.Map(model,passagem);

            _repo.Update(passagem);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<PassagemDTO>(passagem));
            }

            return BadRequest("Registro não atualizado!");
        }

        [HttpPatch("{id}")] 
        public IActionResult Patch(int id,PassagemDTO model)
        {
            var passagem = _repo.GetAllPassagemById(id,false);
            if(passagem == null) return BadRequest("Registro não encontrado!!");

            _mapper.Map(model,passagem);

            _repo.Update(passagem);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<PassagemDTO>(passagem));
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