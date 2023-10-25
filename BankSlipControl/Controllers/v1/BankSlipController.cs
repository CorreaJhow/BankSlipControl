using AutoMapper;
using BankSlipControl.Domain.Entities.v1.BankSlipEntitie;
using BankSlipControl.Domain.InputModels.v1.Bank;
using BankSlipControl.Domain.InputModels.v1.BankSlip;
using BankSlipControl.Domain.Services.v1.BankContract;
using BankSlipControl.Domain.Services.v1.BankSlipContract;
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
                var bankId = await _bankSlipService.CreateBankSlip(bankSlip);

                if (bankId is null)
                    return NotFound("Unable to create BankSlip");

                return CreatedAtAction(nameof(GetBankBillById), new { id = bankId.Id }, bankId.Id);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating BankSlip: {ex.Message}");
            }
        }

        [HttpGet("/v1/bankslip/{id}")]
        public async Task<IActionResult> GetBankBillById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bankSlip = await _bankSlipService.GetBankBillById(id);

            if (bankSlip is null)
                return NotFound();

            if(DateTime.Now > bankSlip.ExpiryDate)
            {
                var bank = await 
            }
            // Regra de negócio:
            // Se o boleto estiver sendo buscado após a data de vencimento,
            // o valor deve ser calculado com o percentual de juros do banco em questão.

            // Aqui você precisa implementar a lógica para recuperar o boleto do banco de dados
            // com base no ID fornecido e verificar se está sendo buscado após a data de vencimento.

            // Exemplo fictício: 
            //    var boleto = await _repository.GetBoletoById(id);

            //    if (boleto == null)
            //    {
            //        return NotFound(); // Ou BadRequest(), dependendo do contexto.
            //    }

            //    // Verifique se está após a data de vencimento
            //    if (DateTime.Now > boleto.DataVencimento)
            //    {
            //        // Calcule o valor com o percentual de juros do banco em questão
            //        //var banco = await _repository.GetBancoById(boleto.BancoId);
            //        //var valorComJuros = boleto.Valor + (boleto.Valor * banco.PercentualJuros / 100);

            //        // Retorne os dados com o valor atualizado
            //        return Ok(new { boleto.Id, boleto.NomePagador, boleto.DataVencimento, ValorComJuros = valorComJuros });
            //    }

            //    // Caso contrário, retorne os dados do boleto sem juros
            //    return Ok(boleto);
            //}

            return Ok();
        }
    }
}
