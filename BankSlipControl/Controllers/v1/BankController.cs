﻿using AutoMapper;
using BankSlipControl.Domain.Entities.v1.BankEntitie;
using BankSlipControl.Domain.InputModels.v1.Bank;
using BankSlipControl.Domain.Services.v1.BankService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankSlipControl.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;
        private readonly IMapper _mapper;
        public BankController(IBankService bankService,
                              IMapper mapper)
        {
            _bankService = bankService;
            _mapper = mapper;
        }

        [HttpPost("/v1/bank")]
        public async Task<IActionResult> CreateBank(BankInputModel newBankInputModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var bank = _mapper.Map<Bank>(newBankInputModel);
                var createdBank = await _bankService.CreateBank(bank);

                if (createdBank is null)
                    return NotFound("Unable to create Bank");

                return Ok(createdBank);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating Bank: {ex.Message}");
            }
        }

        [HttpGet("/v1/bank")]
        public async Task<IActionResult> GetAllBanks()
        {
            try
            {
                var banks = await _bankService.GetAllBanks();

                if (banks is null || banks.Count == 0)
                {
                    return NotFound("No registered bank");
                }

                return Ok(banks);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while processing the request: {ex.Message}");
            }
        }

        [HttpGet("/v1/bank/{code}")]
        public async Task<IActionResult> GetBankByCode(int code)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var bank = await _bankService.GetBankByCode(code);

                if (bank is null)
                    return NotFound();

                return Ok(bank);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred while processing the request: {ex.Message}");
            }
        }
    }
}
