using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using LagerStatusEksamen;

namespace LagerStatusEksamen.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        [HttpGet("db")]
        public IActionResult TestDb()
        {
            try
            {
                using var conn = new SqlConnection(Secret.ConnectionString);
                conn.Open(); // Try to open the database
                return Ok(new { success = true, message = "Database connected successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
