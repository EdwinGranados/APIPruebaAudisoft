using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAudisoft.Context;
using PruebaTecnicaAudisoft.Models;

namespace PruebaTecnicaAudisoft.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProfesorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Profesors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profesor>>> GetProfesor()
        {
          if (_context.Profesor == null)
          {
              return NotFound();
          }
            return await _context.Profesor.ToListAsync();
        }

        // GET: api/Profesors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesor>> GetProfesor(int id)
        {
          if (_context.Profesor == null)
          {
              return NotFound();
          }
            var profesor = await _context.Profesor.FindAsync(id);

            if (profesor == null)
            {
                return NotFound();
            }

            return profesor;
        }

        // PUT: api/Profesors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfesor(int id, Profesor profesor)
        {
            if (id != profesor.id)
            {
                return BadRequest();
            }

            _context.Entry(profesor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesorExists(id))
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

        // POST: api/Profesors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Profesor>> PostProfesor(Profesor profesor)
        {
          if (_context.Profesor == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Profesor'  is null.");
          }
            _context.Profesor.Add(profesor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfesor", new { id = profesor.id }, profesor);
        }

        // DELETE: api/Profesors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesor(int id)
        {
            if (_context.Profesor == null)
            {
                return NotFound();
            }
            var profesor = await _context.Profesor.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }

            _context.Profesor.Remove(profesor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfesorExists(int id)
        {
            return (_context.Profesor?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
