using System;

namespace ClubeDaLeitura
{
    public class Emprestimo
    {
        public Amigo Amigo;
        public Revista Revista;
        public DateTime DataEmprestimo;
        public DateTime DataDevolucao;

        public Emprestimo(Amigo amigo, Revista revista)
        {
            Amigo = amigo;
            Revista = revista;
            DataEmprestimo = DateTime.Now;
            DataDevolucao = DataEmprestimo.AddDays(Revista.Categoria.DiasEmprestimo);
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