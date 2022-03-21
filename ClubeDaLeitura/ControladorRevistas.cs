using System;

namespace ClubeDaLeitura
{
    public class ControladorRevistas
    {
        public Revista[] revistas = new Revista[100];
        public int numeroRevistas = 0;
        public ControladorDeCaixas ControladorCaixas;
        public ControladorCategorias ControladorCategorias;

        public ControladorRevistas(ControladorDeCaixas controladorCaixas, ControladorCategorias controladorCategorias)
        {
            ControladorCaixas = controladorCaixas;
            ControladorCategorias = controladorCategorias;
            PopularRevistas();
        }

        public void PopularRevistas()
        {
            string nome = "Liga da Justiça";
            string tipo = "Super-Heróis";
            string edicao = "4930";
            string ano = "1977";
            Categoria categoria = ControladorCategorias.categorias[0];

            revistas[0] = new Revista(nome, tipo, edicao, ano, ControladorCaixas.caixas[1], categoria);

            nome = "Akira";
            tipo = "Sci-Fi";
            edicao = "7";
            ano = "1985";
            categoria = ControladorCategorias.categorias[3];

            revistas[1] = new Revista(nome, tipo, edicao, ano, ControladorCaixas.caixas[0], categoria);

            nome = "Conan";
            tipo = "Medieval";
            edicao = "101";
            ano = "1968";
            categoria = ControladorCategorias.categorias[2];

            revistas[2] = new Revista(nome, tipo, edicao, ano, ControladorCaixas.caixas[3], categoria);

            nome = "Naruto";
            tipo = "Shounen";
            edicao = "207";
            ano = "2007";
            categoria = ControladorCategorias.categorias[1];

            revistas[3] = new Revista(nome, tipo, edicao, ano, ControladorCaixas.caixas[2], categoria);
        }

        public void CadastrarRevista(Revista revista)
        {
            revistas[numeroRevistas++] = revista;
        }
    }
}