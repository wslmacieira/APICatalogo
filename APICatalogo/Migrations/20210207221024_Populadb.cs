using Microsoft.EntityFrameworkCore.Migrations;

namespace APICatalogo.Migrations
{
    public partial class Populadb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into categoria(Nome, ImagemUrl) Values('Bebidas'," +
                "'http://example/imagens/categoria1.jpg')");
            mb.Sql("Insert into categoria(Nome, ImagemUrl) Values('Lanches'," +
                "'http://example/imagens/categoria2.jpg')");
            mb.Sql("Insert into categoria(Nome, ImagemUrl) Values('Sobremesas'," +
                "'http://example/imagens/categoria3.jpg')");

            mb.Sql("Insert into produto (Nome, Descricao, Preco, ImagemUrl, Estoque," +
                "DataCadastro, IdCategoria) Values('Coca-Cola','Refrigerante de cola 350ml'," +
                "4.50,'http://example/imagens/produto1.jpg',100,now()," +
                "(Select Id from categoria where Nome='Bebidas'))");

             mb.Sql("Insert into produto (Nome, Descricao, Preco, ImagemUrl, Estoque," +
                "DataCadastro, IdCategoria) Values('X-Salada', 'Lanche com hamburguer e salada'," +
                "12.50,'http://example/imagens/produto1.jpg', 100, now()," +
                "(Select Id from categoria where Nome='Lanches'))");

             mb.Sql("Insert into produto (Nome, Descricao, Preco, ImagemUrl, Estoque," +
                "DataCadastro, Idcategoria) Values('Pudim 100g', 'Pudim de leite de 100g'," +
                "4.50,'http://example/imagens/produto1.jpg', 100, now()," +
                "(Select Id from categoria where Nome='Sobremesas'))");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from categoria");
            mb.Sql("delete from produto");
        }
    }
}
