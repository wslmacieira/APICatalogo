using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly CatalogoDbContext _context;
        public CategoriasController(CatalogoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return _context.Categorias.AsNoTracking().ToList();
        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetProdutosPorCategoria()
        {
            return _context.Categorias.Include(p => p.Produtos).ToList();
        }

        [HttpGet("{id}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(c => c.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        [HttpPost]
        public ActionResult<Categoria> Post(Categoria categoria)
        {
            _context.Add(categoria); // salva em memória
            _context.SaveChanges(); // salva na tabela do banco
            return new CreatedAtRouteResult("ObterCategoria",
                new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Categoria categoria)
        {

            if (id != categoria.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }
            _context.Remove(categoria);
            _context.SaveChanges();
            return categoria;
        }
    }
}
