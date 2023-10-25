using AutoMapper;
using BankSlipControl.Domain.Entities.v1.BankEntitie;
using BankSlipControl.Domain.InputModels.v1.Bank;

namespace BankSlipControl.Domain.Mappers.v1.BankProfile
{
    public class BankProfile : Profile
    {
        public BankProfile()
        {
            CreateMap<BankInputModel, Bank>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.InterestPercentage, opt => opt.MapFrom(src => src.InterestPercentage));
        }
    }
}