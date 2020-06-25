using System.Collections.Generic;

namespace Blog.ViewModels.Admin
{
    public class AdminPostagensRemoverViewModel : ViewModelAreaAdministrativa
    {
        public int IdPostagem { get; set; }
        
        public string TituloPostagem { get; set; }
        
        public string Erro { get; set; }
        
        public AdminPostagensRemoverViewModel()
        {
            TituloPagina = "Remover Postagem: ";
        }
    }
}