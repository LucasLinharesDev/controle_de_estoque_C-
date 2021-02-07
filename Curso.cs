using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controle_de_estoque
{
    [System.Serializable]
    class Curso:Produto, Iestoque
    {
        public string autor;
        private int vagas;

        public Curso (string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar Vagas no curso: {nome}");
            Console.WriteLine($"Digite a quantidade: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada;
            Console.WriteLine("Entrada Registrada com sucesso!");
            Console.ReadLine();

        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saída nas vagas do curso: {nome}");
            Console.WriteLine($"Digite a quantidade de saída de vagas: ");
            int saida = int.Parse(Console.ReadLine());
            vagas -= saida;
            Console.WriteLine("Saída Registrada com sucesso!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome do Curso:{this.nome}");
            Console.WriteLine($"Autor do Curso:{this.autor}");
            Console.WriteLine($"Preço do Curso:{this.preco}");
            Console.WriteLine($"´Vagas Disponíveis{this.vagas}");
            Console.WriteLine("====================================");
        }
    }
}
