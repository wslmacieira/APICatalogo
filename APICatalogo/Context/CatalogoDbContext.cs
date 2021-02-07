using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context
{
    public class CatalogoDbContext : DbContext
    {
        //Essa classe de contexto vai representar uma sessão com o banco de dados
        public CatalogoDbContext(DbContextOptions<CatalogoDbContext> options)
            : base(options)
        {

        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
