namespace ClubeDaLeitura
{
    public class Revista
    {
        public string NomeRevista;
        public string Tipo;
        public string Edicao;
        public string Ano;
        public bool Emprestada;
        public bool Reservada;
        public Caixa Caixa;
        public Categoria Categoria;

        public Revista(string nomeRevista, string tipo, string edicao, string ano, Caixa caixa, Categoria categoria)
        {
            NomeRevista = nomeRevista;
            Tipo = tipo;
            Edicao = edicao;
            Ano = ano;
            Caixa = caixa;
            Categoria = categoria;
            Emprestada = false;
            Reservada = false;
        }

        public override string ToString()
        {
            return $"\nNome da revista: {NomeRevista}" +
                $"\nTipo: {Tipo}" +
                $"\nEdição: {Edicao}" +
                $"\nAno: {Ano}" +
                $"\nCategoria: {Categoria.Nome}";
        }
    }
}
