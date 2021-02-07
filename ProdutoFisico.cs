using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_de_estoque
{
    [System.Serializable]
    class ProdutoFisico : Produto, Iestoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico (string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;            
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar entra no estoque do produto: {nome}");
            Console.WriteLine($"Digite a quantidade: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada;
            Console.WriteLine("Entrada Registrada com sucesso!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saída no estoque do produto: {nome}");
            Console.WriteLine($"Digite a quantidade: ");
            int saida = int.Parse(Console.ReadLine());
            estoque -= saida;
            Console.WriteLine("Saída Registrada com sucesso!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome do Produto:{this.nome}");
            Console.WriteLine($"Frete:{this.frete}");
            Console.WriteLine($"Preço do Produto:{this.preco}");
            Console.WriteLine($"Estoque:{this.estoque}");
            Console.WriteLine("====================================");
        }
    }
}
