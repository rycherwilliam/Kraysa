using Application.Models;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly AddTransactionUseCase _addTransactionUseCase;

        public TransactionsController(AddTransactionUseCase addTransactionUseCase)
        {
            _addTransactionUseCase = addTransactionUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] TransactionDto transactionDto)
        {
            if (transactionDto == null)
                return BadRequest("Transaction cannot be null.");

            await _addTransactionUseCase.ExecuteAsync(transactionDto);
            return Ok("Transaction added successfully.");
        }
    }
}
