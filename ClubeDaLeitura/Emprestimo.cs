namespace ClubeDaLeitura
{
    public class Emprestimo
    {
        public Amigo Amigo;
        public Revista Revista;
        public string DataEmprestimo;
        public string DataDevolucao;

        public Emprestimo(Amigo amigo, Revista revista, string dataEmprestimo, string dataDevolucao)
        {
            Amigo = amigo;
            Revista = revista;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
        }

        public override string ToString()
        {
            return $"\nDados do empréstimo: \n" +
                $"\nAmigo: {Amigo.Nome}" +
                $"\nRevista: {Revista.NomeRevista}" +
                $"\nData do emprestimo: {DataEmprestimo}" +
                $"\nData para devolução: {DataDevolucao}";
        }
    }
}