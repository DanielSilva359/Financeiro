using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Domain.Helpers
{
    public class FinanceiroProfile : Profile
    {
        public FinanceiroProfile()
        {
            CreateMap<Boleto, BoletoDto>();
            CreateMap<Banco, BancoDto>();
        }
    }
}
