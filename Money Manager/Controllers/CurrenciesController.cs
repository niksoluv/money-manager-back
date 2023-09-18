using Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Money_Manager.Models;

namespace Money_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CurrenciesController : ControllerBase
    {
        private IRepositoryWrapper _wrapper;
        public CurrenciesController(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }
        [HttpGet("all")]
        [AllowAnonymous]
        public IActionResult GetAll() {
            return Ok(_wrapper.Currency.FindAll());
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] Currency currency)
        {
            _wrapper.Currency.Create(currency);
            _wrapper.SaveAsync();
            return Ok(currency);
        }
        [HttpPost("getbyname")]
        public IActionResult Create([FromBody] string name)
        {
            var currency = _wrapper.Currency.FindByCondition(c => c.CurrencyName == name).FirstOrDefault();
            return Ok(currency);
        }
        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] string name)
        {
            var currency = _wrapper.Currency.FindByCondition(c => c.CurrencyName == name).FirstOrDefault();
            _wrapper.Currency.Delete(currency);
            _wrapper.SaveAsync();
            return Ok();
        }
    }
}
