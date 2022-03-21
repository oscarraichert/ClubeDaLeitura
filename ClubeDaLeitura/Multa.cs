using System;

namespace ClubeDaLeitura
{
    public class Multa
    {
        public int DiasAtraso;
        public int ValorMulta;

        public Multa(int diasAtraso)
        {
            DiasAtraso = diasAtraso;
            ValorMulta = 5;
        }

        public int CalcularMulta()
        {
            int multa = DiasAtraso * ValorMulta;

            return multa;
        }

        public override string ToString()
        {
            return $"Multa de R${CalcularMulta()} com {DiasAtraso} dias de atraso.";
        }
    }
}