using AutoMapper;
using TESTEGARAGENS_DR_WEBAPI.Dtos;
using TESTEGARAGENS_DR_WEBAPI.Models;

namespace TESTEGARAGENS_DR_WEBAPI.Helpers
{
    public class PassagensProfile : Profile
    {
        public PassagensProfile()
        {
            CreateMap<Passagem, PassagemDTO>()
                .ForMember(
                    dest => dest.Estadia,
                    opt => opt.MapFrom(src => src.GetCurrentTime(src.DataHoraEntrada, (System.DateTime)src.DataHoraSaida))
                );
            CreateMap<PassagemDTO, Passagem>();
        }
    }
}