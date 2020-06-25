namespace Blog.ViewModels.Admin
{
    public class AdminAutoresEditarViewModel : ViewModelAreaAdministrativa
    {

        public string Erro { get; set; }
        public string Nome { get; set; }
        public string IdAutor { get; set; }


        public AdminAutoresEditarViewModel()
        {
            TituloPagina = "Autores - Administrador";
        }


    }

}