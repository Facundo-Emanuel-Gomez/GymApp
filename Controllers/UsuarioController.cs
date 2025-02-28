using Microsoft.AspNetCore.Mvc;
using GymApp.Data;
using GymApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace GymApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly GymDbContext _context;

        public UsuariosController(GymDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios);
            Console.WriteLine(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Usuarios.Add(usuario);

                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetUsuarios), new { id = usuario.UsuarioID }, usuario);
            }
            catch (DbUpdateConcurrencyException) 
            {
                return StatusCode(500, "Ha ocurrido un error al intentar guardar un user: ");
            }
        }
    }
}
