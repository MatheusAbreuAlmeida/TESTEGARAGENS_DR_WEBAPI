using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TESTEGARAGENS_DR_WEBAPI.Data;
using TESTEGARAGENS_DR_WEBAPI.Dtos;
using TESTEGARAGENS_DR_WEBAPI.Models;

namespace TESTEGARAGENS_DR_WEBAPI.Controllers
{
    /// <summary>
    /// API DE REGISTRO DE CARROS, CALCULO DE PREÇOS E VALORES DE ESTACIONAMENTOS
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
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
        /// Metodo responsavel por retornar todos os registros de passagens por codigo de garagem
        /// </summary>
        /// <returns></returns>
        [HttpGet("{cod}")] 
        public IActionResult GetPassagensByCod(string cod)
        {
            var result = _repo.GetAllPassagens(cod);
            return Ok(_mapper.Map<IEnumerable<PassagemDTO>>(result));
        }


        /// <summary>
        /// Metodo responsavel por retornar todos os registros de passagens de veiculos que ainda não deram saida, por codigo de garagem
        /// </summary>
        /// <returns></returns>
        [HttpGet("{cod}")] 
        public IActionResult GetTotalPassagensbyCod(string cod)
        {
            var result = _repo.GetTotalPassagens(cod);
            return Ok(_mapper.Map<IEnumerable<PassagemDTO>>(result));
        }


        /// <summary>
        /// Metodo responsavel por retornar todos os registros de passagens de veiculos em determinado periodo, por codigo de garagem
        /// </summary>
        /// <returns></returns>
        [HttpGet("{cod}/{startDate}/{endDate}")] 
        public IActionResult GetTotalPassagensbyCodEmPeriodo (string cod, string startDate, string endDate)
        {
            var result = _repo.GetTotalPassagensWithTimeSpan(cod,startDate,endDate);
            if (result.Length > 0)
            {
                return Ok(_mapper.Map<IEnumerable<PassagemDTO>>(result));
            }
            return BadRequest("Parametros invalidos na busca, corrija os dados enviados como parametros.");
        }

        /// <summary>
        /// Metodo responsavel por retornar todos os registros de passagens de veiculos que ainda não deram saida, por codigo de garagem
        /// </summary>
        /// <returns></returns>
        [HttpGet("{cod}")] 
        public IActionResult GetCarrosSemSaidabyCod(string cod)
        {
            var result = _repo.GetAllPassagensExitLess(cod);
            return Ok(_mapper.Map<IEnumerable<PassagemDTO>>(result));
        }

        /// <summary>
        /// Metodo responsavel por retornar o registro da passagem a partir do codigo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}/{cod}")]   
        public IActionResult GetById(int id, string cod)
        {
            var passagem = _repo.GetPassagemById(id,cod);
            if(passagem == null) return BadRequest("Registro não encontrado!!");

            return Ok(passagem);
        }


        /// <summary>
        ///  Metodo busca garagem a partir do codigo
        /// </summary>
        /// <param name="cod"></param>
        /// <returns></returns>
        [HttpGet("{cod}")]
        public IActionResult GetGaragemByCod(string cod)
        {
            var garagem = _repo.GetGaragemByCod(cod);
            if(garagem == null) return BadRequest("Registro não encontrado!!");

            return Ok(garagem);
        }


        /// <summary>
        /// Metodo busca Forma de pagamento a partir do codigo
        /// </summary>
        /// <param name="cod"></param>
        /// <returns></returns>
        [HttpGet("{cod}")]   
        public IActionResult GetFormaPagamentoByCod(string cod)
        {
            var formaPagamento = _repo.GetFormaPagamentoByCod(cod);
            if(formaPagamento == null) return BadRequest("Registro não encontrado!!");

            return Ok(formaPagamento);
        }


        /// <summary>
        /// Metodo de registro de passagens de veiculos pela garagem
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostPassagens(Passagem[] model)
        {
            foreach (var item in model)
            {
                var passagem = _mapper.Map<Passagem>(item);
                passagem.PrecoTotal = _repo.TotalPrizeCalc(passagem);
                _repo.Add(passagem);
            }

            if (_repo.SaveChanges())
            {
                return Ok("Registros das passagens efetuados com sucesso!");
            }

            return BadRequest("Erro no registro!");
        }


        /// <summary>
        /// Metodo de registro de dados de varias garagens de uma vez só
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostGaragens(Garagem[] model)
        {
            foreach (var item in model)
            {
                var garagens = _mapper.Map<Garagem>(item);
                _repo.Add(garagens);
            }

            if (_repo.SaveChanges())
            {
                return Ok("Registros efetuados com sucesso.");
            }

            return BadRequest("Erro nos registros das formas de pagamento!");
        }


        /// <summary>
        /// Metodo de registro das formas de pagamento
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostFormasPagamento(FormaPagamento[] model)
        {
            foreach (var item in model)
            {
                var formaPagamento = _mapper.Map<FormaPagamento>(item);

                _repo.Add(formaPagamento);

            }

            if (_repo.SaveChanges())
            {
                return Ok("Registro efetuados com sucesso.");
            }

            return BadRequest("Erro no registro da forma de pagamento!");
        }


        /// <summary>
        /// Metodo de atualização de dados sobre as passagens de veiculos pela garagem
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cod"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id:int}/{cod}")]  
        public IActionResult PutPassagem(int id,string cod,Passagem model)
        {
            var passagem = _repo.GetSinglePassagemById(id,cod);
            if(passagem == null) return BadRequest("Registro não encontrado!!");
            if(id > 0) model.Id = passagem.Id;
            _mapper.Map(passagem,model);
            passagem.PrecoTotal = _repo.TotalPrizeCalc(model);

            _repo.Update(model);
            if (_repo.SaveChanges())
            {
                return Created($"/api/passagem/{id}", _mapper.Map<Passagem>(model));
            }

            return BadRequest("Registro não atualizado!");
        }


        /// <summary>
        /// Metodo de atualização de dados das garagens
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cod"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{cod}")]  
        public IActionResult PutGaragem(int? id,string cod,Garagem model)
        {
            var garagem = _repo.GetSingleGaragemByCod(cod);
            if(garagem == null) return BadRequest("Registro não encontrado!!");

            model.Codigo = cod;
            if(id > 0) model.Id = garagem.Id;
            _mapper.Map(model,garagem);

            _repo.Update(model);
            if(_repo.SaveChanges())
            {
                return Created($"/api/passagem/{model.Id}", _mapper.Map<Garagem>(model));
            }

            return BadRequest("Registro não atualizado!");
        }


        /// <summary>
        /// Metodo de atualização de dados das formas de pagamento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cod"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{cod}")]    
        public IActionResult PutFormaPagamento(int? id,string cod,FormaPagamento model)
        {
            var formaPagamento = _repo.GetSingleFormaPagamentoByCod(cod);
            if(formaPagamento == null) return BadRequest("Registro não encontrado!!");

            model.Codigo = cod;
            if(id > 0){model.Id = (int)id;}
            _mapper.Map(model,formaPagamento);

            _repo.Update(model);
            if(_repo.SaveChanges())
            {
                return Created($"/api/passagem/{model.Id}", _mapper.Map<FormaPagamento>(model));
            }

            return BadRequest("Registro não atualizado!");
        }


        /// <summary>
        /// Metodo de atualização de dados das passagens
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cod"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id:int}/{cod}")]  
        public IActionResult PatchPassagem(int id,string cod,Passagem model)
        {
            model.Id = id;
            var passagem = _repo.GetSinglePassagemById(id, cod);
            if(passagem == null) return BadRequest("Registro não encontrado!!");
            _mapper.Map(passagem, model);
            passagem.PrecoTotal = _repo.TotalPrizeCalc(model);

            _repo.Update(model);
            if(_repo.SaveChanges())
            {
                return Created($"/api/passagem/{id}", _mapper.Map<Passagem>(model));
            }

            return BadRequest("Registro não atualizado!");
        }


        /// <summary>
        /// Metodo de atualização de dados das garagens
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cod"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{cod}")]  
        public IActionResult PatchGaragem(int id,string cod,Garagem model)
        {
            var garagem = _repo.GetSingleGaragemByCod(cod);
            if(garagem == null) return BadRequest("Registro não encontrado!!");

            model.Codigo = cod;
            model.Id = garagem.Id;
            _mapper.Map(model, garagem);

            _repo.Update(model);
            if(_repo.SaveChanges())
            {
                return Created($"/api/passagem/{model.Id}", _mapper.Map<Garagem>(model));
            }

            return BadRequest("Registro não atualizado!");
        }


        /// <summary>
        /// Metodo de atualização de dados das formas de pagamento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cod"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{cod}")]  
        public IActionResult PatchFormaPagamento(int id,string cod,FormaPagamento model)
        {
            var formaPagamento = _repo.GetSingleFormaPagamentoByCod(cod);
            if(formaPagamento == null) return BadRequest("Registro não encontrado!!");

            model.Codigo = cod;
            model.Id = formaPagamento.Id;
            _mapper.Map(model, formaPagamento);

            _repo.Update(model);
            if(_repo.SaveChanges())
            {
                return Created($"/api/passagem/{model.Id}", _mapper.Map<FormaPagamento>(model));
            }

            return BadRequest("Registro não atualizado!");
        }


        /// <summary>
        /// Metodo de remoção de dados das passagens dos veiculos pelas garagens
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cod"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}/{cod}")]  
        public IActionResult DeletePassagem(int id,string cod)
        {
            var passagem = _repo.GetSinglePassagemById(id,cod);
            if(passagem == null) return BadRequest("Registro não encontrado!!");

            _repo.Delete(passagem);
            if(_repo.SaveChanges())
            {
                return Ok("Registro deletado!");
            }

            return BadRequest("Registro não deletado!");
        }


        /// <summary>
        /// Metodo de remoção de dados das garagens
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cod"></param>
        /// <returns></returns>
        [HttpDelete("{cod}")]
        public IActionResult DeleteGaragem(int id, string cod)
        {
            var garagem = _repo.GetSingleGaragemByCod(cod);
            if(garagem == null) return BadRequest("Registro de garagem não encontrado!!");
            garagem.Id = id;

            _repo.Delete(garagem);
            if(_repo.SaveChanges())
            {
                return Ok("Registro de garagem deletado!");
            }

            return BadRequest("Registro de garagem não deletado!");
        }


        /// <summary>
        /// Metodo de remoção de dados das formas de pagamento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cod"></param>
        /// <returns></returns>
        [HttpDelete("{cod}")]
        public IActionResult DeleteFormaPagamento(int id,string cod)
        {
            var formaPagamento = _repo.GetSingleFormaPagamentoByCod(cod);
            if(formaPagamento == null) return BadRequest("Registro de forma de pagamento não encontrado!!");
            formaPagamento.Id = id;

            _repo.Delete(formaPagamento);
            if(_repo.SaveChanges())
            {
                return Ok("Registro de forma de pagamento deletado!");
            }

            return BadRequest("Registro de forma de pagamento não deletado!");
        }
    }
}