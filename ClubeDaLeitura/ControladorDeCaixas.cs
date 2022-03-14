namespace ClubeDaLeitura
{
    public class ControladorDeCaixas
    {
        public Caixa[] caixas = new Caixa[5];

        public ControladorDeCaixas()
        {
            PopularCaixas();
        }

        public Caixa SelecionarCaixa(int indice)
        {
            return caixas[indice]; 
        }

        public void PopularCaixas()
        {
            string cor = "Branca";
            string etiqueta = "Ficção";
            string numero = "84659";

            caixas[0] = new Caixa(cor, etiqueta, numero);

            cor = "Azul";
            etiqueta = "Heróis";
            numero = "64739";

            caixas[1] = new Caixa(cor, etiqueta, numero);

            cor = "Verde";
            etiqueta = "Animes";
            numero = "09372";

            caixas[2] = new Caixa(cor, etiqueta, numero);

            cor = "Preta";
            etiqueta = "Medieval";
            numero = "43628";

            caixas[3] = new Caixa(cor, etiqueta, numero);

            cor = "Vermelha";
            etiqueta = "Carros";
            numero = "21638";

            caixas[4] = new Caixa(cor, etiqueta, numero);
        }
    }
}