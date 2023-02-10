using GestãoDeClientes.Entities;
using GestãoDeClientes.Enums;
using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace GestaoDeClientes
{
    public class Program
    {
        static List<Cliente> clientes = new List<Cliente>();
        static bool escolheuSair = false;
        static void Main(string[] args)
        {
            Carregar();
            while (!escolheuSair)
            {
                Menu();
            }

        }

        static void Menu()
        {
            Console.WriteLine("\t\t\t\t--------------------------------------------------");
            Console.WriteLine("\t\t\t\t\tSistema de Clientes - Bem vindo(a)!");
            Console.WriteLine("\t\t\t\t--------------------------------------------------\n");
            Console.WriteLine("1 - Adicionar\n2 - Lista de clientes\n3 - Remover\n0 - Sair\n");
            Console.Write("Digite a opção desejada: ");
            int intOp = int.Parse(Console.ReadLine());
            MenuCliente opcao = (MenuCliente)intOp;

            switch (opcao)
            {
                case MenuCliente.Sair:
                    Console.Clear();
                    escolheuSair = true;
                    Console.WriteLine("Programa encerrado!!!");
                    break;
                case MenuCliente.Adicionar:
                    Adicionar();
                    break;
                case MenuCliente.Listagem:
                    Listagem();
                    break;
                case MenuCliente.Remover:
                    Remover();
                    break;
            }
        }

        private static void Remover()
        {
            Console.Clear();
            Listagem();
            Console.Write("\nDigite o ID do cliente que deseja remover: ");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id < clientes.Count)
            {
                Console.Clear();
                clientes.RemoveAt(id);
                Console.WriteLine("\nCliente removido com sucesso!");
            } else
            {
                Console.Clear();
                Console.WriteLine("ID não encontrado!\n");
            }
        }

        private static void Listagem()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\tLista de Clientes\n\n");
            int i = 0;
            if (clientes.Count > 0)
            {
                foreach (Cliente cliente in clientes)
                {
                    Console.WriteLine($"ID: {i}\nNome: {cliente.Nome}\nEmail: {cliente.Email}\nCPF: {cliente.Cpf}");
                    Console.WriteLine("------------------------------------------------");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Não há clientes cadastrados!\n\n");
            }
        }

        private static void Adicionar()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\tTela de Cadastro\n\n");
            Console.Write("Nome do cliente: ");
            string nome = Console.ReadLine();
            Console.Write("Email do cliente: ");
            string email = Console.ReadLine();
            Console.Write("CPF do cliente: ");
            string cpf = Console.ReadLine();
            clientes.Add(new Cliente(nome, email, cpf));
            Salvar();

            Console.WriteLine("\nCliente cadastrado com sucesso!");
            Console.WriteLine("\nPressione ENTER para sair");
            Console.ReadLine();
            Console.Clear();
        }

        private static void Salvar()
        {
            FileStream stream = new FileStream("clientes.txt", FileMode.OpenOrCreate);
            BinaryFormatter enconder = new BinaryFormatter();

            enconder.Serialize(stream, clientes);
            stream.Close();
        }

        private static void Carregar()
        {
            FileStream stream = new FileStream("clientes.txt", FileMode.OpenOrCreate);
            try
            {
                BinaryFormatter enconder = new BinaryFormatter();

                clientes = (List<Cliente>)enconder.Deserialize(stream);

                if (clientes == null)
                    clientes = new List<Cliente>();
            }
            catch (Exception e)
            {
                clientes = new List<Cliente>();
            }
            stream.Close();
        }
    }
}