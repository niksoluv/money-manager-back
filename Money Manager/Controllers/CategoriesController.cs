using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Money_Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IRepositoryWrapper _wrapper;
        public CategoriesController(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(_wrapper.Category.FindAll());
        }
    }
}
