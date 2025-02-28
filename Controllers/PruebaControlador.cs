using Microsoft.AspNetCore.Mvc;
using GymApp.Data;

namespace GymApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PruebaController : ControllerBase
    {
        private readonly GymDbContext _context;

        public PruebaController(GymDbContext context)
        {
            _context = context;
        }

        // GET: api/Prueba/Conexion
        [HttpGet("Conexion")]
        public IActionResult VerificarConexion()
        {
            try
            {
                // Intenta acceder a la base de datos
                var existeConexion = _context.Database.CanConnect();

                if (existeConexion)
                {
                    return Ok(new { mensaje = "Conexión exitosa con la base de datos" });
                }
                else
                {
                    return BadRequest(new { mensaje = "No se pudo conectar a la base de datos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al verificar la conexión", error = ex.Message });
            }
        }
    }
}
