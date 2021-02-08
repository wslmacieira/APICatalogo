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
    public class ProdutosController : ControllerBase
    {
        private readonly CatalogoDbContext _context;
        public ProdutosController(CatalogoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return _context.Produtos.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name ="ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if(produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            _context.Produtos.Add(produto); // Apenas na memoria
            _context.SaveChanges(); // Salvar no banco commit
            return new CreatedAtRouteResult("ObterProduto", 
                new { id = produto.Id }, produto );
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Produto produto)
        {
            if(id != produto.Id)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Produto> Delete(int id)
        {
            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(p => p.Id == id);

            if(produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto); // remove na memoria
            _context.SaveChanges(); // exclui da tabela do banco
            return produto;
        }
    }
}
