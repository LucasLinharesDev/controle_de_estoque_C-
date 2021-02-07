using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace controle_de_estoque
{
    class Program
    {
        static List<Iestoque> produtos = new List<Iestoque>();
        enum Menu { listar =1, adicionar, remover, entrada, saída, sair}

        static void Main(string[] args)
        {
            Carregar();
            bool sair = true;
            while (sair)
            {
                Console.WriteLine("=====Sistema de GEstão de Vendas - ELITE TECNOLOGIA=====");
                Console.WriteLine(" (1) Exibir Produtos\n (2) Adicionar Produto\n (3) Remover produto\n (4) Registrar Entrada\n (5) Registrar Saída\n (6) Sair do programa");
                string opcaostring = Console.ReadLine();
                int opcaoint = int.Parse(opcaostring);

                if (opcaoint>=1 && opcaoint<=6)
                {
                    Menu escolhaenum = (Menu)opcaoint;

                    switch (escolhaenum)
                    {
                        case Menu.listar:
                            Listagem();
                            break;
                        case Menu.adicionar:
                            Cadastro();
                            break;
                        case Menu.remover:
                            Remover();
                            break;
                        case Menu.entrada:
                            Entrada();
                            break;
                        case Menu.saída:
                            Saida();
                            break;
                        case Menu.sair:
                            Console.WriteLine("Saindo do programa...");
                            sair = false;
                            break;
                    }
                }
                else
                {
                    sair = false;
                }
                Console.Clear();
            }
            
        }

        static void Cadastro()
        {
            Console.WriteLine("Selecione o tipo de produto que deseja cadastrar:");
            Console.WriteLine("(1)Produto Físico\n(2)Ebook\n(3)Curso");
            string opcaostring = Console.ReadLine();
            int opcaoint = int.Parse(opcaostring);

            switch (opcaoint)
            {
                case 1:
                    CadastrarPFisico();
                    break;
                case 2:
                    CadastrarEbook();
                    break;
                case 3:
                    CadastrarCurso();
                    break;
            }

        }
        
        static void CadastrarPFisico()
        {
            Console.WriteLine("Cadastro de Produto Físico:");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            float frete = float.Parse(Console.ReadLine());
            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }
        
        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastro de Ebook");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("autor: ");
            string autor = Console.ReadLine();
            Ebook ebook = new Ebook(nome, preco, autor);
            produtos.Add(ebook);
            Salvar();
        }
        
        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastro de Curso");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("autor: ");
            string autor = Console.ReadLine();
            Curso curso = new Curso(nome, preco, autor);
            produtos.Add(curso);
            Salvar();
        }

        static void Listagem()
        {
            Console.WriteLine("======Lista de Produtos:======");
            int i = 0;
            foreach (Iestoque produto in produtos)
            {
                Console.WriteLine($"ID: {i}");
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }
        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do produto a ser removido: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id <= produtos.Count)
            {
                produtos.RemoveAt(id);
            }
            else
            {
                Console.WriteLine("ID Inválido!");
            }
            Salvar();
        }
        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do produto para dar entrada: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id <= produtos.Count)
            {
                produtos[id].AdicionarEntrada(); // acessa o produto pelo ID, e executa metodo AdicionarEntrada
            }
            Salvar();
        }
        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do produto para registrar saída ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id <= produtos.Count)
            {
                produtos[id].AdicionarSaida(); // acessa o produto pelo ID, e executa metodo AdicionarSaida
            }
            Salvar();
        }
        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat",FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);
            stream.Close();
        }
        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtos = (List<Iestoque>)encoder.Deserialize(stream);
                if (produtos == null)
                {
                    produtos = new List<Iestoque>();
                }
            }
            catch (Exception ex)
            {
                produtos = new List<Iestoque>();
            }
            stream.Close();
            
        }
    }
}
