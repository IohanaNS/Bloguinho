using System.Collections.Generic;

namespace Blog.ViewModels.Admin
{
    public class AdminAutoresListarViewModel : ViewModelAreaAdministrativa
    {

        public ICollection<AutorAdminAutores> Autores { get; set; }
        public AdminAutoresListarViewModel()
        {
            TituloPagina = "Autores - Administrador";
            Autores = new List<AutorAdminAutores>();
        }
    }
    public class AutorAdminAutores
    {
        public string IdAutor { get; set; }
        public string NomeAutor { get; set; }
    }
}