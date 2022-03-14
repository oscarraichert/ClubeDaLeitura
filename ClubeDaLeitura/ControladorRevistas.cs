using System;

namespace ClubeDaLeitura
{
    public class ControladorRevistas
    {
        public Revista[] revistas = new Revista[100];
        public int numeroRevistas = 0;

        public void CadastrarRevista(Revista revista)
        {
            revistas[numeroRevistas++] = revista;
        }
    }
}