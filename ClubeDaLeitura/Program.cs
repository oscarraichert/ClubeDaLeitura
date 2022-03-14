using System;

namespace ClubeDaLeitura
{
    internal class Program
    {
        public static ControladorDeCaixas controladorCaixas = new();
        public static ControladorRevistas controladorRevistas = new();
        public static ControladorAmigos controladorAmigos = new();
        public static Emprestimo[] emprestimos = new Emprestimo[100];
        public static int numeroEmprestimos = 0;

        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            string opcao = "";

            while (opcao != "5")
            {
                Console.WriteLine("(1) Para cadastrar uma revista. " +
                    "\n(2) Para cadastrar um amigo." +
                    "\n(3) Para cadastrar um empréstimo." +
                    "\n(4) Para visualizar emprestimos." +
                    "\n(5) Sair.");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine();
                        CadastrarRevista();
                        Console.WriteLine();
                        break;

                    case "2":
                        Console.WriteLine();
                        CadastrarAmigo();
                        Console.WriteLine();
                        break;

                    case "3":
                        Console.WriteLine();
                        RealizarEmprestimo();
                        Console.WriteLine();
                        break;

                    case "4":
                        Console.WriteLine();
                        MostrarEmprestimos();
                        Console.WriteLine();
                        break;

                    case "5":
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        Console.WriteLine();
                        break;
                }
            }
        }

        public static void CadastrarAmigo()
        {
            Console.WriteLine("Insira os dados para cadastrar o amigo: \n");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo(nome, nomeResponsavel, telefone, endereco);

            controladorAmigos.CadastrarAmigo(amigo);
        }

        public static void CadastrarRevista()
        {
            Console.WriteLine("Insira os dados para cadastrar a revista: \n");

            Console.Write("Nome da revista: ");
            string nome = Console.ReadLine();

            Console.Write("Tipo de revista: ");
            string tipo = Console.ReadLine();

            Console.Write("Edição da revista: ");
            string edicao = Console.ReadLine();

            Console.Write("Ano da revista: ");
            string ano = Console.ReadLine();

            Caixa caixa = EscolherCaixa();

            Revista revista = new Revista(nome, tipo, edicao, ano, caixa);

            controladorRevistas.CadastrarRevista(revista);
        }

        private static Caixa EscolherCaixa()
        {
            Console.WriteLine("\nCaixa que a revista será guardada: \n");
            MostrarCaixas();
            int indice = Convert.ToInt32(Console.ReadLine()) - 1;
            Caixa caixa = controladorCaixas.SelecionarCaixa(indice);
            return caixa;
        }

        public static void MostrarCaixas()
        {
            for (int i = 0; i < controladorCaixas.caixas.Length; i++)
            {
                Console.WriteLine($"Caixa {i + 1}\n" + controladorCaixas.caixas[i]);
                Console.WriteLine();
            }
        }

        public static void RealizarEmprestimo()
        {
            Console.WriteLine("Informe os dados para o emprestimo: \n");

            Console.WriteLine("Amigo que está pegando o livro: \n");
            MostrarAmigos();
            int indice = Convert.ToInt32(Console.ReadLine()) - 1;

            if (controladorAmigos.amigos[indice].Revista != null)
            {
                Console.WriteLine($"{controladorAmigos.amigos[indice].Nome} já está com uma revista!");
                return;
            }

            Amigo amigo = controladorAmigos.amigos[indice];


            Console.WriteLine("Revista que está sendo emprestada: \n");
            MostrarRevistas();
            int indiceRevista = Convert.ToInt32(Console.ReadLine()) - 1;

            if (controladorRevistas.revistas[indiceRevista].Amigo != null)
            {
                Console.WriteLine("A revista ja está emprestada!");
                return;
            }
            controladorRevistas.revistas[indiceRevista].Amigo = amigo;

            Revista revista = controladorRevistas.revistas[indiceRevista];

            Console.Write("Data do emprestimo: ");
            string dataE = Console.ReadLine();

            Console.Write("Data da devolução: ");
            string dataD = Console.ReadLine();

            Emprestimo emprestimo = new Emprestimo(amigo, revista, dataE, dataD);
            emprestimos[numeroEmprestimos++] = emprestimo;
        }

        public static void MostrarRevistas()
        {
            for (int i = 0; i < controladorRevistas.revistas.Length; i++)
            {
                if (controladorRevistas.revistas[i] != null)
                {
                    Console.WriteLine($"Revista {i + 1}\n" + controladorRevistas.revistas[i]);
                    Console.WriteLine();
                }
            }
        }

        public static void MostrarEmprestimos()
        {
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                {
                    Console.WriteLine($"Emprestimo {i + 1}\n" + emprestimos[i]);
                    Console.WriteLine();
                }
            }
        }

        public static void MostrarAmigos()
        {
            for (int i = 0; i < controladorAmigos.amigos.Length; i++)
            {
                if (controladorAmigos.amigos[i] != null)
                {
                    Console.WriteLine($"Amigo {i + 1}\n" + controladorAmigos.amigos[i]);
                    Console.WriteLine();
                }
            }
        }
    }
}