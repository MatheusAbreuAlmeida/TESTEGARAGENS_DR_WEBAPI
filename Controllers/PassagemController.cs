using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using TESTEGARAGENS_DR_WEBAPI.Models;

namespace TESTEGARAGENS_DR_WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassagemController : ControllerBase
    {
        public List<Passagens> Passagens = new List<Passagens>(){
            new Passagens() {
                Id = 1,
                Garagem = "EVO01",
                CarroPlaca = "ABC-0O12",
                CarroMarca = "Honda",
                CarroModelo = "FIT",
                DataHoraEntrada = "04/09/2023 13:30",
                DataHoraSaida = "04/09/2023 15:15",
                FormaPagamento = "PIX",
            },
            new Passagens() {
                Id = 2,
                Garagem = "EVO01",
                CarroPlaca = "DKO-3927",
                CarroMarca = "Toyota",
                CarroModelo = "Yaris",
                DataHoraEntrada = "05/09/2023 08:40",
                DataHoraSaida = "05/09/2023 09:55",
                FormaPagamento = "CCR",
            },
            new Passagens() {
                Id = 3,
                Garagem = "EVO01",
                CarroPlaca = "SPE-9F42",
                CarroMarca = "Fiat",
                CarroModelo = "Argo",
                DataHoraEntrada = "04/09/2023 10:15",
                DataHoraSaida = "04/09/2023 11:20",
                FormaPagamento = "TAG",
            }
        };
        public PassagemController() {}

        [HttpGet]  
        public IActionResult Get()
        {
            return Ok(Passagens);
        }

        [HttpGet("{id}")]  
        public IActionResult GetById(int id)
        {
            var passagem = Passagens.FirstOrDefault(x => x.Id == id);
            if(passagem == null) return BadRequest("Registro não encontrado!!");
            return Ok(passagem);
        }

        [HttpPost]
        public IActionResult Post(Passagens passagens)
        {
            return Ok(Passagens);
        }

        [HttpPut("{id}")] 
        public IActionResult Put(int id,Passagens passagens)
        {
            return Ok(Passagens);
        }

        [HttpPatch("{id}")] 
        public IActionResult Patch(int id,Passagens passagens)
        {
            return Ok(Passagens);
        }

        [HttpDelete("{id}")] 
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}