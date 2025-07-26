using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;

namespace TestCICD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnsafeController : ControllerBase
    {
        [HttpPost("deserialize")]
        public IActionResult Deserialize([FromBody] SafeInput model)
        {
            
            // Assume the input is a UTF-8 encoded JSON object
            string jsonString = System.Text.Encoding.UTF8.GetString(model.input);
            DeserializedObject obj = JsonSerializer.Deserialize<DeserializedObject>(jsonString);
            return Ok(obj?.ToString());
        }
        [HttpPost("Test")]
        public IActionResult Test()
        {
            int x = 4 + 5+10 + 20 +10;
            return Ok(x);
        }
    }
    public class SafeInput
    {
        public string Data { get; set; }
        public byte[] input { get; set; }
    }
    // Define a POCO for safe deserialization
    public class DeserializedObject
    {
        public string? Property1 { get; set; }
        public int? Property2 { get; set; }
        public override string ToString()
        {
            return $"Property1: {Property1}, Property2: {Property2}";
        }
    }
}
