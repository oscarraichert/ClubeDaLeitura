namespace ClubeDaLeitura
{
    public class ControladorCategorias
    {
        public Categoria[] categorias = new Categoria[10];
        public int numCategorias = 0;

        public ControladorCategorias()
        {
            PopularCategorias();
        }

        public void CadastrarCategoria(Categoria categoria)
        {
            categorias[numCategorias++] = categoria;
        }

        public void PopularCategorias()
        {
            string nome = "Novidade";
            int dias = 3;

            categorias[numCategorias++] = new Categoria(nome, dias);

            nome = "Semi-Novos";
            dias = 5;

            categorias[numCategorias++] = new Categoria(nome, dias);

            nome = "Coleção";
            dias = 7;

            categorias[numCategorias++] = new Categoria(nome, dias);

            nome = "Populares";
            dias = 4;

            categorias[numCategorias++] = new Categoria(nome, dias);
        }
    }
}