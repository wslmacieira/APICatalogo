using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models
{
    [Table("categoria")]
    public class Categoria
    {
        public Categoria()
        {
            // Quando tiver uma definição de collection tem que definir a inicialização
            Produtos = new Collection<Produto>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string Nome { get; set; }
        public string ImagemUrl { get; set; }

        public ICollection<Produto> Produtos { get; set; } // propriedade de navegação
    }
}
