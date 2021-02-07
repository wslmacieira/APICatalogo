using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace APICatalogo.Models
{
    public class Categoria
    {
        public Categoria()
        {
            // Quando tiver uma definição de collection tem que definir a inicialização
            Produtos = new Collection<Produto>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string ImagemUrl { get; set; }

        public ICollection<Produto> Produtos { get; set; } // propriedade de navegação
    }
}
