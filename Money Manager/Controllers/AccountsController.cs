using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Money_Manager.Models;
using Money_Manager.Services;

namespace Money_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private IRepositoryWrapper _wrapper;
        public AccountsController(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var currentUser = await _wrapper.User.GetByUsername(User.Identity.Name);
            if (currentUser.Role == "Admin")
            {
                var users = _wrapper.User.FindAll();
                return Ok(users);
            }
            return Forbid("You don't have acces for this resource");
        }
        [HttpGet("my")]
        public async Task<IActionResult> GetAccounts()
        {
            var currentUser = await _wrapper.User.GetByUsername(User.Identity.Name);
            var accounts = _wrapper.Account.FindByCondition(
                acc => acc.User == currentUser);
            return Ok(accounts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid accountId)
        {
            var currentUser = await _wrapper.User.GetByUsername(User.Identity.Name);
            var account = _wrapper.Account.FindByCondition(
                acc => acc.User == currentUser && acc.Id == accountId).FirstOrDefault();
            return Ok(account);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Account account)
        {
            var currentUser = await _wrapper.User.GetByUsername(User.Identity.Name);
            account.User = currentUser;
            await _wrapper.Account.Create(account);
            await _wrapper.SaveAsync();
            return Ok(account);
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid accountId)
        {
            var currentUser = await _wrapper.User.GetByUsername(User.Identity.Name);
            Account acc = _wrapper.Account.FindByCondition(acc => acc.User == currentUser).FirstOrDefault();
            _wrapper.Account.Delete(acc);
            await _wrapper.SaveAsync();
            return Ok();
        }
    }
}
