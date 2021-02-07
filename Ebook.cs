using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_de_estoque
{
    [System.Serializable]
    class Ebook : Produto, Iestoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco,string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Produto Ebook~é digital, não utiliza estoque!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar vendo no Ebook: {nome}");
            Console.WriteLine($"Digite a quantidade de venda: ");
            int saida = int.Parse(Console.ReadLine());
            vendas += saida;
            Console.WriteLine("Venda Registrada com sucesso!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome do Ebook: {this.nome}");
            Console.WriteLine($"Autor do Ebook: {this.autor}");
            Console.WriteLine($"Preço do Ebook: {this.preco}");
            Console.WriteLine($"Quantidade de Vendas: {this.vendas}");
            Console.WriteLine("====================================");
        }
    }
}
