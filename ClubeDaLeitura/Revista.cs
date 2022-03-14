namespace ClubeDaLeitura
{
    public class Revista
    {
        public string NomeRevista;
        public string Tipo;
        public string Edicao;
        public string Ano;
        public Caixa Caixa;
        public Amigo Amigo;

        public Revista(string nomeRevista, string tipo, string edicao, string ano, Caixa caixa)
        {
            NomeRevista = nomeRevista;
            Tipo = tipo;
            Edicao = edicao;
            Ano = ano;
            Caixa = caixa;
        }

        public override string ToString()
        {
            return $"\nNome da revista: {NomeRevista}" +
                $"\nTipo: {Tipo}" +
                $"\nEdição: {Edicao}" +
                $"\nAno: {Ano}";
        }
    }
}
