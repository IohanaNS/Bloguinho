namespace Blog.ViewModels.Admin
{
    public class AdminAutoresCriarViewModel : ViewModelAreaAdministrativa
    {

        public string Erro { get; set; }
        public string Nome { get; set; }
        public string IdAutor { get; set; }


        public AdminAutoresCriarViewModel()
        {
            TituloPagina = "Autores - Administrador";
        }


    }

}