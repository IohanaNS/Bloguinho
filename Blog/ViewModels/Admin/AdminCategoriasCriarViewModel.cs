namespace Blog.ViewModels.Admin
{
    public class AdminCategoriasCriarViewModel : ViewModelAreaAdministrativa
    {


        public string Erro { get; set; }
        public string Nome { get; set; }
        public string IdCategoria { get; set; }

        public AdminCategoriasCriarViewModel()
        {
            TituloPagina = "Categorias - Administrador";
        }
    }
}