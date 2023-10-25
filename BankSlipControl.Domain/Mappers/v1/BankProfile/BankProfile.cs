using AutoMapper;
using BankSlipControl.Domain.Entities.v1.BankEntitie;
using BankSlipControl.Domain.InputModels.v1.Bank;

namespace BankSlipControl.Domain.Mappers.v1.BankProfile
{
    public class BankProfile : Profile
    {
        public BankProfile()
        {
            CreateMap<BankInputModel, Bank>();
        }
    }
}