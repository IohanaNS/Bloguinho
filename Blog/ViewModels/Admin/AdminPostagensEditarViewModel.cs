using System.Collections.Generic;

namespace Blog.ViewModels.Admin
{
    public class AdminPostagensEditarViewModel : ViewModelAreaAdministrativa
    {
        public int IdPostagem { get; set; }
        
        public string NomePostagem { get; set; }
        
        public int IdCategoriaPostagem { get; set; }
        public int IdAutorPostagem { get; set; }
        public int IdEtiquetaPostagem { get; set; }

        public string TextoPostagem { get; set; }
        public string DescricaoPostagem { get; set; }
        public string DataInicioPostagem { get; set; }

        
        public string Erro { get; set; }

        public ICollection<CategoriaAdminPostagens> Categorias { get; set; }
        public ICollection<EtiquetasAdminPostagens> Etiquetas { get; set; }
        public ICollection<AutoresAdminPostagens> Autores { get; set; }
        
        
        public AdminPostagensEditarViewModel()
        {
            TituloPagina = "Editar Postagem: ";
            Categorias = new List<CategoriaAdminPostagens>();
            Etiquetas = new List<EtiquetasAdminPostagens>();
            Autores = new List<AutoresAdminPostagens>();
        }
    }
}