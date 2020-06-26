namespace Blog.ViewModels.Admin
{
    public class AdminCategoriasEditarViewModel : ViewModelAreaAdministrativa
    {


        public string Erro { get; set; }
        public string Nome { get; set; }
        public int IdCategoria { get; set; }
        public AdminCategoriasEditarViewModel()
        {
            TituloPagina = "Categorias - Administrador";
        }
    }
}