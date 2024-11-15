using LivrariaAPI.Data;
using LivrariaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Bdlivrariauni9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly LivrariaContext _context;

        public LivroController(LivrariaContext context)
        {
            _context = context;
        }

        // GET: api/Livro
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {
            try
            {
                var livros = await _context.Livros.ToListAsync();
                return Ok(livros);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro no servidor", message = ex.Message });
            }
        }

        // GET: api/Livro/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            try
            {
                var livro = await _context.Livros.FindAsync(id);

                if (livro == null)
                {
                    return NotFound(new { error = "Livro não encontrado", message = $"Livro com ID {id} não encontrado." });
                }

                return Ok(livro);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro no servidor", message = ex.Message });
            }
        }

        // POST: api/Livro
        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro(Livro livro)
        {
            try
            {
                _context.Livros.Add(livro);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetLivro), new { id = livro.IdLivro }, livro);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro ao criar livro", message = ex.Message });
            }
        }

        // PUT: api/Livro/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, Livro livro)
        {
            if (id != livro.IdLivro)
            {
                return BadRequest(new { error = "ID do livro não corresponde ao ID da URL", message = "O ID fornecido não corresponde ao ID do livro." });
            }

            try
            {
                _context.Entry(livro).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Livros.Any(e => e.IdLivro == id))
                {
                    return NotFound(new { error = "Livro não encontrado", message = $"Livro com ID {id} não encontrado." });
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro ao atualizar livro", message = ex.Message });
            }
        }

        // DELETE: api/Livro/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            try
            {
                var livro = await _context.Livros.FindAsync(id);
                if (livro == null)
                {
                    return NotFound(new { error = "Livro não encontrado", message = $"Livro com ID {id} não encontrado." });
                }

                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Erro ao deletar livro", message = ex.Message });
            }
        }
    }
}
