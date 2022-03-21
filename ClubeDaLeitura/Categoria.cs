namespace ClubeDaLeitura
{
    public class Categoria
    {
        public string Nome;
        public int DiasEmprestimo;        

        public Categoria(string nome, int diasEmprestimo)
        {
            Nome = nome;
            DiasEmprestimo = diasEmprestimo;
        }

        public override string ToString()
        {
            return $"\nCategoria: {Nome}" +
                $"\nDias de empréstimo: {DiasEmprestimo}\n";
        }
    }
}
