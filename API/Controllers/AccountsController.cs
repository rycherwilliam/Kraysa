using Application.Adapters;
using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountsController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountDto accountDto)
        {
            if (accountDto == null)
                return BadRequest("Account cannot be null.");

            var account = AccountAdapter.ToDomain(accountDto);
            await _accountRepository.AddAsync(account);

            return Ok("Account created successfully.");
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetAccount(Guid accountId)
        {
            if (accountId == Guid.Empty)
                return BadRequest("AccountId cannot be empty.");

            var account = await _accountRepository.GetByIdAsync(accountId);
            if (account == null)
                return NotFound("Account not found.");

            return Ok(account);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await _accountRepository.GetAllAsync();
            return Ok(accounts);
        }
    }
}
