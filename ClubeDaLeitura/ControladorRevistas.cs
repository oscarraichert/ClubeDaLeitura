using System;

namespace ClubeDaLeitura
{
    public class ControladorRevistas
    {
        public Revista[] revistas = new Revista[100];
        public int numeroRevistas = 0;
        public ControladorDeCaixas ControladorCaixas;

        public ControladorRevistas(ControladorDeCaixas controladorCaixas)
        {
            ControladorCaixas = controladorCaixas;
            PopularRevistas();
        }

        private void PopularRevistas()
        {
            string nome = "Liga da Justiça";
            string tipo = "Super-Heróis";
            string edicao = "4930";
            string ano = "1977";

            revistas[0] = new Revista(nome, tipo, edicao, ano, ControladorCaixas.caixas[1]);

            nome = "Akira";
            tipo = "Sci-Fi";
            edicao = "7";
            ano = "1985";

            revistas[1] = new Revista(nome, tipo, edicao, ano, ControladorCaixas.caixas[0]);

            nome = "Conan";
            tipo = "Medieval";
            edicao = "101";
            ano = "1968";

            revistas[2] = new Revista(nome, tipo, edicao, ano, ControladorCaixas.caixas[3]);

            nome = "Naruto";
            tipo = "Shounen";
            edicao = "207";
            ano = "2007";

            revistas[3] = new Revista(nome, tipo, edicao, ano, ControladorCaixas.caixas[2]);
        }

        public void CadastrarRevista(Revista revista)
        {
            revistas[numeroRevistas++] = revista;
        }
    }
}