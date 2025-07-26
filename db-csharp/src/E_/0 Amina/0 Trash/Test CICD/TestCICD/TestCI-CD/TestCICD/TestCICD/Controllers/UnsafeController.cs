using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestCICD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnsafeController : ControllerBase
    {
        [HttpPost("deserialize")]
        public IActionResult Deserialize([FromBody] byte[] input)
        {
            // ❌ Insecure Deserialization (detected by CodeQL)
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream(input))
            {
                object obj = formatter.Deserialize(stream); // Vulnerability here
                return Ok(obj.ToString());
            }
        }
    }
}
