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
        public IActionResult Deserialize([FromBody] SafeInput model)
        {
            
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream(model.input))
            {
                object obj = formatter.Deserialize(stream); // Vulnerability here
                return Ok(obj.ToString());
            }
        }
    }
    public class SafeInput
    {
        public string Data { get; set; }
        public byte[] input { get; set; }
    }
}
