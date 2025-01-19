using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Application.UseCases.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly ICreateAccountUseCase _createAccountUseCase;
        private readonly IGetAccountUseCase _getAccountUseCase;

        public AccountsController(
            ICreateAccountUseCase createAccountUseCase,
            IGetAccountUseCase getAccountUseCase)
        {
            _createAccountUseCase = createAccountUseCase;
            _getAccountUseCase = getAccountUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountDto accountDto)
        {
            if (accountDto == null)
                return BadRequest("Account cannot be null.");

            await _createAccountUseCase.ExecuteAsync(accountDto);

            return Ok("Account created successfully.");
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetAccount(Guid accountId)
        {
            if (accountId == Guid.Empty)
                return BadRequest("AccountId cannot be empty.");

            var account = await _getAccountUseCase.GetByIdAsync(accountId);
            if (account == null)
                return NotFound("Account not found.");

            return Ok(account);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await _getAccountUseCase.GetAllAsync();
            return Ok(accounts);
        }
    }
}
