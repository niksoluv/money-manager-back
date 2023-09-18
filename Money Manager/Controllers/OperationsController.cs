using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Money_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly IRepositoryWrapper _wrapper;
        public OperationsController(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllOperations()
        {
            var currentUser = await _wrapper.User.GetByUsername(User.Identity.Name);
            if (currentUser.Role == "Admin")
            {
                return Ok(_wrapper.Operation.FindAll());
            }
            return Forbid("You don't have acces for this resource");
        }
        [HttpGet("my")]
        public async Task<IActionResult> GetMyOperations()
        {
            var currentUser = await _wrapper.User.GetByUsername(User.Identity.Name);
            var operations = _wrapper.Operation.FindByCondition(o => o.Account.User == currentUser);
            return Ok(operations);
        }
        [HttpPost("add")]
        public IActionResult Create([FromBody] Operation operation)
        {
            _wrapper.Operation.Create(operation);
            _wrapper.SaveAsync();
            return Ok(operation);
        }
        [HttpPut("update")]
        public IActionResult Update([FromBody] Operation operation)
        {
            _wrapper.Operation.Update(operation);
            _wrapper.SaveAsync();
            return Ok(operation);
        }
        [HttpPut("delete")]
        public IActionResult Delete([FromBody] Operation operation)
        {
            _wrapper.Operation.Delete(operation);
            _wrapper.SaveAsync();
            return Ok(operation);
        }
    }
}
