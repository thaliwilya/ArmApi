using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly ILogger<PlaceController> _logger;
        public PlaceController(ILogger<PlaceController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into PlaceController");
        }
        // GET: api/<PlaceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PlaceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PlaceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PlaceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlaceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
