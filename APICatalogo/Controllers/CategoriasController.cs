using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Http;
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
            try
            {
                return _context.Categorias.AsNoTracking().ToList();
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter as categorias do banco de dados");
            }

        }

        [HttpGet("produtos")]
        public ActionResult<IEnumerable<Categoria>> GetProdutosPorCategoria()
        {
            try
            {
                return _context.Categorias.Include(p => p.Produtos).ToList();
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter as categorias do banco de dados");
            }

        }

        [HttpGet("{id}", Name = "ObterCategoria")]
        public ActionResult<Categoria> Get(int id)
        {
            try
            {
                var categoria = _context.Categorias.AsNoTracking().FirstOrDefault(c => c.Id == id);

                if (categoria == null)
                {
                    return NotFound();
                }

                return categoria;
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao obter a categoria com o {id} do banco de dados");
            }

        }

        [HttpPost]
        public ActionResult<Categoria> Post(Categoria categoria)
        {
            try
            {
                _context.Add(categoria); // salva em memória
                _context.SaveChanges(); // salva na tabela do banco
                return new CreatedAtRouteResult("ObterCategoria",
                    new { id = categoria.Id }, categoria);
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Erro ao cadastrar a categoria no banco de dados");
            }

        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Categoria categoria)
        {
            try
            {
                if (id != categoria.Id)
                {
                    return BadRequest();
                }

                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok();
            }
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao atualiza a categoria com o {id} no banco de dados");
            }

        }

        [HttpDelete("{id}")]
        public ActionResult<Categoria> Delete(int id)
        {
            try
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
            catch (System.Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   $"Erro ao excluir a categoria com o {id} no banco de dados");
            }

        }
    }
}
