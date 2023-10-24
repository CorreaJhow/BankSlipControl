using Microsoft.AspNetCore.Mvc;

namespace BankSlipControl.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BankSlipController : ControllerBase
    {

        [HttpPost("api/v1/bankbill")]
        public async Task<IActionResult> CreateBankBill() ///passar DTO de boleto bancario 
        {
            return Ok();
        }

        [HttpPost("api/v1/bank")]
        public async Task<IActionResult> CreateBank() ///passar DTO de banco
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


        [HttpGet("api/v1/bankbill/{id}")]
        public async Task<IActionResult> GetBankBillById(int id)
        {
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
