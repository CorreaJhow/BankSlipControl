using AutoMapper;
using BankSlipControl.Domain.Entities.v1.BankSlipEntitie;
using BankSlipControl.Domain.InputModels.v1.BankSlip;

namespace BankSlipControl.Domain.Mappers.v1.BankSlipProfile
{
    public class BankSlipProfile : Profile
    {
        public BankSlipProfile()
        {
            CreateMap<BankSlipInputModel, BankSlip>()
           .ForMember(dest => dest.PayerName, opt => opt.MapFrom(src => src.PayerName))
           .ForMember(dest => dest.DocumentPayer, opt => opt.MapFrom(src => src.DocumentPayer))
           .ForMember(dest => dest.BeneficiaryName, opt => opt.MapFrom(src => src.BeneficiaryName))
           .ForMember(dest => dest.DocumentBeneficiary, opt => opt.MapFrom(src => src.DocumentBeneficiary))
           .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
           .ForMember(dest => dest.ExpiryDate, opt => opt.MapFrom(src => src.ExpiryDate))
           .ForMember(dest => dest.Observation, opt => opt.MapFrom(src => src.Observation))
           .ForMember(dest => dest.BankId, opt => opt.MapFrom(src => src.BankId));
        }
    }
}
