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

        public void PopularAmigos()
        {
            string nome = "João Xavier";
            string nomeResponsavel = "Carlon";
            string telefone = "(49)9993728";
            string endereco = "José Linhares 170";

            amigos[numeroAmigos++] = new Amigo(nome, nomeResponsavel, telefone, endereco);
        }
    }
}