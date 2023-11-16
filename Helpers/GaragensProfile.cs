using AutoMapper;
using TESTEGARAGENS_DR_WEBAPI.Dtos;
using TESTEGARAGENS_DR_WEBAPI.Models;

namespace TESTEGARAGENS_DR_WEBAPI.Helpers
{
    public class GaragensProfile : Profile
    {
        public GaragensProfile()
        {
            CreateMap<Passagem, PassagemDTO>()
                .ForMember(
                    dest => dest.Estadia,
                    opt => opt.MapFrom(src => src.GetCurrentTime(src.DataHoraEntrada,src.DataHoraSaida))
                );
            CreateMap<PassagemDTO, Passagem>();
        }
    }
}