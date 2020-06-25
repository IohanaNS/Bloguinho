namespace Blog.ViewModels.Admin
{
    public class AdminCategoriasRemoverViewModel : ViewModelAreaAdministrativa
    {

        public string Erro { get; set; }
        public string Nome { get; set; }
        public string IdCategoria { get; set; }
        public AdminCategoriasRemoverViewModel()
        {
            TituloPagina = "Categorias - Administrador";
        }
    }
}