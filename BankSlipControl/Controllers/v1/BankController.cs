using BankSlipControl.Domain.InputModels.v1.Bank;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankSlipControl.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {

        [HttpPost("api/v1/bank")]
        public async Task<IActionResult> CreateBank(NewBankInputModel newBankInputModel)
        {
            return Ok();
        }

        [HttpGet("api/v1/bank")]
        public async Task<IActionResult> GetAllBanks()
        {
            return Ok(); //return all banks 
        }

        [HttpGet("api/v1/bank/{code}")]
        public async Task<IActionResult> GetBankById(int code)
        {
            // Exemplo fictício:
            //var banco = await _repository.GetBancoByCode(code);

            //if (banco == null)
            //{
            //    return NotFound(); // Ou BadRequest(), dependendo do contexto.
            //}

            //// Retorne os dados do banco
            //return Ok(new { banco.Id, banco.NomeBanco, banco.CodigoBanco, banco.PercentualJuros });

            return Ok();
        }
    }
}
