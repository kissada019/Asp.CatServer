using CatServerApi.IRepo;
using CatServerApi.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo repo;
        public EmployeeController(IEmployeeRepo repo) {
        this.repo = repo;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var _list = await this.repo.GetAll();
            if( _list != null ) 
            {
                return Ok( _list );
            }else
            {
                return NotFound();
            }
        }

        [HttpGet("GetbyId/{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var _list = await this.repo.GetbyId(id);
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetAllbyrole/{role}")]
        public async Task<IActionResult> GetAllbyrole(string role)
        {
            var _list = await this.repo.GetAllbyrole(role);
            if (_list != null)
            {
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            var _result = await this.repo.Create(employee);
            return Ok( _result );
           
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] Employee employee, int Id)
        {
            var _result = await this.repo.Update(employee, Id);
            return Ok(_result);

        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove( int Id)
        {
            var _result = await this.repo.Remove(Id);
            return Ok(_result);

        }
    }
}
