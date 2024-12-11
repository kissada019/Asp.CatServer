using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CatServerApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors, ApiController]
    public class PermossionController : ControllerBase
    {
        // GET: api/<PermossionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PermossionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PermossionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PermossionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PermossionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
