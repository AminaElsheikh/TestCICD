using Microsoft.AspNetCore.Mvc;

namespace TestCICD.Controllers
{
    public class SafeInput
    {
        public string Data { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class UnsafeController : ControllerBase
    {
        [HttpPost("deserialize")]
        public IActionResult Deserialize([FromBody] SafeInput input)
        {
            // ✅ Safe deserialization using model binding to a POCO
            return Ok(input.Data);
        }
    }
}
