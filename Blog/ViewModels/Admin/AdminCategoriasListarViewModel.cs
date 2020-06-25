using System.Collections.Generic;

namespace Blog.ViewModels.Admin
{
    public class AdminCategoriasListarViewModel : ViewModelAreaAdministrativa
    {

        public ICollection<CategoriaAdminCategorias> Categorias { get; set; }
        public AdminCategoriasListarViewModel()
        {
            TituloPagina = "Categorias - Administrador";
            Categorias = new List<CategoriaAdminCategorias>();
        }
    }
    public class CategoriaAdminCategorias
    {
        public string IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
    }
}