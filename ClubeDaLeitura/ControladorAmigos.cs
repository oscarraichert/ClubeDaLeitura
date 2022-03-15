using System;

namespace ClubeDaLeitura
{
    public class ControladorAmigos
    {
        public Amigo[] amigos = new Amigo[100];
        public int numeroAmigos = 0;

        public void CadastrarAmigo(Amigo amigo)
        {
            amigos[numeroAmigos++] = amigo;
        }
    }
}