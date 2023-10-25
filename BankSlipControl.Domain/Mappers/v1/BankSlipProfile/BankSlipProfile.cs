using AutoMapper;
using BankSlipControl.Domain.Entities.v1.BankSlipEntitie;
using BankSlipControl.Domain.InputModels.v1.BankSlip;

namespace BankSlipControl.Domain.Mappers.v1.BankSlipProfile
{
    public class BankSlipProfile : Profile
    {
        public BankSlipProfile()
        {
            CreateMap<BankSlipInputModel, BankSlip>();
        }
    }
}
