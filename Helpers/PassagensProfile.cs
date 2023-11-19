using AutoMapper;
using TESTEGARAGENS_DR_WEBAPI.Dtos;
using TESTEGARAGENS_DR_WEBAPI.Models;

namespace TESTEGARAGENS_DR_WEBAPI.Helpers
{
    public class PassagensProfile : Profile
    {
        public PassagensProfile()
        {
            CreateMap<Passagem, PassagemDTO>().ReverseMap();
        }
    }
}