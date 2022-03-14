namespace ClubeDaLeitura
{
    public class Amigo
    {
        public string Nome;
        public string NomeResponsavel;
        public string Telefone;
        public string Endereco;
        public Revista Revista;

        public Amigo(string nome, string nomeResponsavel, string telefone, string endereco)
        {
            Nome = nome;
            NomeResponsavel = nomeResponsavel;
            Telefone = telefone;
            Endereco = endereco;
        }

        public override string ToString()
        {
            return $"\nNome: {Nome}" +
                $"\nNome do responsável: {NomeResponsavel}" +
                $"\nEndereço: {Endereco}" +
                $"\nTelefone: {Telefone}";
        }
    }
}