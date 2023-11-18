using AutoMapper;
using TESTEGARAGENS_DR_WEBAPI.Dtos;
using TESTEGARAGENS_DR_WEBAPI.Models;

namespace TESTEGARAGENS_DR_WEBAPI.Helpers
{
    public class FormasPagamentoProfile : Profile
    {
        public FormasPagamentoProfile()
        {
            CreateMap<FormaPagamento, FormaPagamentoDTO>().ReverseMap();
        }
    }
}