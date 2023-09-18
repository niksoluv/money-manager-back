using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Money_Manager.Models;

namespace Money_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountGroupsController : ControllerBase
    {
        private IRepositoryWrapper _wrapper;
        public AccountGroupsController(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }
        [HttpGet("all")]
        [AllowAnonymous]
        public IActionResult GetAll() {
            return Ok(_wrapper.AccountGroup.FindAll());
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] AccountGroup accountGroup)
        {
            _wrapper.AccountGroup.Create(accountGroup);
            _wrapper.SaveAsync();
            return Ok(accountGroup);
        }
        [HttpPost("getbyname")]
        public IActionResult Create([FromBody] string name)
        {
            var accountGroup = _wrapper.AccountGroup.FindByCondition(c => c.Name == name).FirstOrDefault();
            return Ok(accountGroup);
        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] string name)
        {
            var accountGroup = _wrapper.AccountGroup.FindByCondition(c => c.Name == name).FirstOrDefault();
            _wrapper.AccountGroup.Delete(accountGroup);
            _wrapper.SaveAsync();
            return Ok();
        }
    }
}
