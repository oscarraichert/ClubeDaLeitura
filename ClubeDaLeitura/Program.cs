using System;

namespace ClubeDaLeitura
{
    internal class Program
    {
        public static ControladorCategorias controladorCategorias = new();
        public static ControladorDeCaixas controladorCaixas = new();
        public static ControladorRevistas controladorRevistas = new(controladorCaixas, controladorCategorias);
        public static ControladorAmigos controladorAmigos = new();
        public static Emprestimo[] emprestimos = new Emprestimo[100];
        public static Reserva[] reservas = new Reserva[100];
        public static int numReservas = 0;
        public static int numeroEmprestimos = 0;


        static void Main(string[] args)
        {
            controladorAmigos.PopularAmigos();
            Menu();
        }

        public static void Menu()
        {
            string opcao = "";

            while (opcao != "10")
            {
                Console.WriteLine("(1) Para cadastrar uma revista. " +
                    "\n(2) Para cadastrar um amigo." +
                    "\n(3) Para cadastrar um empréstimo." +
                    "\n(4) Para visualizar emprestimos." +
                    "\n(5) Para cadastrar uma categoria." +
                    "\n(6) Para cadastrar uma reserva." +
                    "\n(7) Para realizar uma devolução." +
                    "\n(8) Para visualizar as multas em aberto." +
                    "\n(9) Para fechar multas." +
                    "\n(10) Sair.");

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
                        CadastrarEmprestimo();
                        Console.WriteLine();
                        break;

                    case "4":
                        Console.WriteLine();
                        MostrarEmprestimos();
                        Console.WriteLine();
                        break;

                    case "5":
                        Console.WriteLine();
                        CadastrarCategoria();
                        Console.WriteLine();
                        break;

                    case "6":
                        Console.WriteLine();
                        CadastrarReserva();
                        Console.WriteLine();
                        break;

                    case "7":
                        Console.WriteLine();
                        Devolução();
                        Console.WriteLine();
                        break;

                    case "8":
                        Console.WriteLine();
                        MostrarMultas();
                        Console.WriteLine();
                        break;

                    case "9":
                        Console.WriteLine();
                        FecharMulta();
                        Console.WriteLine();
                        break;

                    case "10":
                        break;

                    default:
                        Console.WriteLine("Opção inválida");
                        Console.WriteLine();
                        break;
                }
            }
        }

        private static void FecharMulta()
        {
            Console.WriteLine("Selecione uma multa que foi paga para fecha-la: \n");
            MostrarMultas();

            int indiceMulta = Convert.ToInt32(Console.ReadLine()) - 1;

            controladorAmigos.amigos[indiceMulta].Multa = null;
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

            Categoria categoria = EscolherCategoria();

            Revista revista = new Revista(nome, tipo, edicao, ano, caixa, categoria);

            controladorRevistas.CadastrarRevista(revista);
        }

        public static Categoria EscolherCategoria()
        {
            Console.WriteLine("Selecione a categoria da revista: \n");
            MostrarCategorias();

            int indice = Convert.ToInt32(Console.ReadLine()) - 1;

            return controladorCategorias.categorias[indice];
        }

        private static void MostrarCategorias()
        {
            for (int i = 0; i < controladorCategorias.categorias.Length; i++)
            {
                if (controladorCategorias.categorias[i] != null)
                {
                    Console.WriteLine($"Item {i + 1}:{controladorCategorias.categorias[i]}");
                }
            }
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

        public static void CadastrarEmprestimo()
        {
            Console.WriteLine("Informe os dados para o emprestimo: \n");

            Console.WriteLine("Amigo que está pegando o livro: \n");
            MostrarAmigos();
            int indice = Convert.ToInt32(Console.ReadLine()) - 1;

            Amigo amigo = controladorAmigos.amigos[indice];
            
            if (amigo.Revista != null)
            {
                Console.WriteLine($"{amigo.Nome} já está com uma revista!");
                return;
            }

            if (amigo.Multa != null)
            {
                Console.WriteLine("Não pode fazer empréstimo com multa em aberto!");
                return;
            }

            Console.WriteLine("Revista que está sendo emprestada: \n");
            MostrarRevistas();
            int indiceRevista = Convert.ToInt32(Console.ReadLine()) - 1;

            Revista revista = controladorRevistas.revistas[indiceRevista];

            if (revista.Reservada == true && PegarReserva(revista).Amigo != amigo)
            {
                Console.WriteLine("Esta revista está reservada!");
                return;
            }

            if (revista.Emprestada == true)
            {
                Console.WriteLine("Esta revista está emprestada!");
                OferecerReserva(amigo, revista);
                return;
            }

            revista.Emprestada = true;

            Emprestimo emprestimo = new Emprestimo(amigo, revista);
            emprestimos[numeroEmprestimos++] = emprestimo;
        }

        public static Reserva PegarReserva(Revista revista)
        {
            foreach (Reserva reserva in reservas)
            {
                if (reserva.Revista == revista)
                {
                    return reserva;
                }
            }

            return null;
        }

        private static void OferecerReserva(Amigo amigo, Revista revista)
        {
            Console.WriteLine("Gostaria de reservá-la?\n\n(1) Sim\n(2) Não");
            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                PegarEmprestimo(revista);
                CadastrarReserva(PegarEmprestimo(revista), amigo);
            }
        }

        private static Emprestimo PegarEmprestimo(Revista revista)
        {
            foreach (Emprestimo emprestimoFeito in emprestimos)
            {
                if (emprestimoFeito.Revista == revista)
                {
                    return emprestimoFeito;
                }
            }

            return null;
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

        public static void CadastrarCategoria()
        {
            Console.WriteLine("Informe os dados para cadastrar a categoria: \n");

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Dias de empréstimo: ");
            int dias = Convert.ToInt32(Console.ReadLine());

            Categoria categoria = new(nome, dias);
            controladorCategorias.CadastrarCategoria(categoria);
        }

        public static void CadastrarReserva(Emprestimo emprestimo, Amigo amigo)
        {
            reservas[numReservas++] = new(amigo, emprestimo.Revista, emprestimo.DataDevolucao);
            emprestimo.Revista.Reservada = true;
        }

        public static void CadastrarReserva()
        {
            Console.WriteLine("Informe os dados para fazer uma reserva: \n");

            Console.WriteLine("Selecione o amigo: \n");
            MostrarAmigos();
            int indiceAmigo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Selecione a revista: \n");
            MostrarRevistas();
            int indiceRevista = Convert.ToInt32(Console.ReadLine());

            controladorRevistas.revistas[indiceRevista].Reservada = true;
            reservas[numReservas++] = new(controladorAmigos.amigos[indiceAmigo], controladorRevistas.revistas[indiceRevista], DateTime.Now);
        }

        public static void Devolução()
        {
            Console.WriteLine("Selecione o empréstimo que está sendo devolvido: \n");

            MostrarEmprestimos();
            int numeroEmprestimo = Convert.ToInt32(Console.ReadLine()) - 1;

            Emprestimo emprestimo = emprestimos[numeroEmprestimo];
            if (emprestimo.DataDevolucao < DateTime.Now)
            {                                
                Multa(emprestimo);
            }

            emprestimo.Revista.Emprestada = false;
        }

        public static void MostrarMultas()
        {
            int i = 0;
            foreach (Amigo amigo in controladorAmigos.amigos)
            {                
                i++;
                if (amigo != null && amigo.Multa != null)
                {
                    Console.WriteLine($"({i}){amigo} tem uma {amigo.Multa}");
                }
            }
        }

        public static void Multa(Emprestimo emprestimo)
        {
            emprestimo.Amigo.Multa = new Multa((DateTime.Now - emprestimo.DataDevolucao).Days);
        }
    }
}