using System;

namespace ClubeDaLeitura
{
    public class Reserva
    {
        public Amigo Amigo;
        public Revista Revista;
        public DateTime DataReserva;
        public DateTime DataLimite;

        public Reserva(Amigo amigo, Revista revista, DateTime dataReserva)
        {
            Amigo = amigo;
            Revista = revista;
            DataReserva = dataReserva;
            DataLimite = DataReserva.AddDays(2);
        }
    }
}