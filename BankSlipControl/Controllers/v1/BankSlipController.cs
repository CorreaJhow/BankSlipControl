using AutoMapper;
using BankSlipControl.Domain.Entities.v1.BankSlipEntitie;
using BankSlipControl.Domain.InputModels.v1.BankSlip;
using BankSlipControl.Domain.Services.v1.BankService;
using BankSlipControl.Domain.Services.v1.BankSlipService;
using Microsoft.AspNetCore.Mvc;

namespace BankSlipControl.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankSlipController : ControllerBase
    {
        private readonly IBankSlipService _bankSlipService;
        private readonly IBankService _bankService;
        private readonly IMapper _mapper;
        public BankSlipController(IBankSlipService bankSlipService,
                                  IBankService bankService,
                                  IMapper mapper)
        {
            _bankSlipService = bankSlipService;
            _bankService = bankService;
            _mapper = mapper;
        }

        [HttpPost("/v1/bankslip")]
        public async Task<IActionResult> CreateBankSlip(BankSlipInputModel newBankSlipInputModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var bankSlip = _mapper.Map<BankSlip>(newBankSlipInputModel);
                var createBankSlip = await _bankSlipService.CreateBankSlip(bankSlip);

                if (createBankSlip is null)
                    return NotFound("Unable to create BankSlip");

                return Ok(createBankSlip);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating BankSlip: {ex.Message}");
            }
        }

        [HttpGet("/v1/bankslip/{id}")]
        public async Task<IActionResult> GetBankBillById(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var bankSlip = await _bankSlipService.GetBankBillById(id);

                if (bankSlip is null)
                    return NotFound();

                if (DateTime.Now > bankSlip.ExpiryDate)
                {
                    var bank = await _bankService.GetBankById(bankSlip.BankId);

                    bankSlip.Value = bankSlip.Value + (bankSlip.Value * bank.InterestPercentage / 100);
                }

                return Ok(bankSlip);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while processing the request: {ex.Message}");
            }
        }
    }
}
