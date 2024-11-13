using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APISenac.Models.Profile;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebApplication1.Data;
using System;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContex _context;

        public ProfileController(AppDbContex context)
        {
            _context = context;
        }

        // GET: api/Profile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
        {
            return await _context.Profiles
                                 .Include(p => p.Sistema)
                                 .ToListAsync();
        }

        // GET: api/Profile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> GetProfile(Guid id)
        {
            var profile = await _context.Profiles
                                        .Include(p => p.Sistema)
                                        .FirstOrDefaultAsync(p => p.Id == id);

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }

        // POST: api/Profile
        [HttpPost]
        public async Task<ActionResult<Profile>> CreateProfile(Profile profile)
        {
            profile.Id = Guid.NewGuid(); // Gera um novo Guid para o Id
            profile.LastUpdate = DateTime.Now; // Define a última atualização como a data atual
            profile.Active = true; // Define o profile como ativo
            profile.UsuarioInserido = "Usuário Teste"; // Isso pode ser substituído por um valor real (JWT ou sessão)

            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfile), new { id = profile.Id }, profile);
        }

        // PUT: api/Profile/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(Guid id, Profile profile)
        {
            if (id != profile.Id)
            {
                return BadRequest();
            }

            // Atualiza a última modificação
            profile.LastUpdate = DateTime.Now;

            // Marca como modificado
            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Profile/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(Guid id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            // Ao invés de excluir o registro fisicamente, você pode apenas desativá-lo
            profile.Active = false;
            profile.LastUpdate = DateTime.Now; // Atualiza a data de modificação

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfileExists(Guid id)
        {
            return _context.Profiles.Any(e => e.Id == id);
        }
    }
}
