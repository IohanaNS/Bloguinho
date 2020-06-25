using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using System;
using System.Collections.Generic;

namespace Blog.ViewModels.Admin
{
    public class AdminPostagensCriarViewModel : ViewModelAreaAdministrativa
    {
        public string Erro { get; set; }

        public ICollection<CategoriaAdminPostagens> Categorias { get; set; }
        public ICollection<EtiquetasAdminPostagens> Etiquetas { get; set; }
        public ICollection<AutoresAdminPostagens> Autores { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public AutorEntity Autor { get; set; }

        public String Texto { get; set; }


        public AdminPostagensCriarViewModel()
        {
            TituloPagina = "Criar nova Postagem";
            Categorias = new List<CategoriaAdminPostagens>();
            Etiquetas = new List<EtiquetasAdminPostagens>();
            Autores = new List<AutoresAdminPostagens>();

        }
    }

    public class EtiquetasAdminPostagens
    {
        public int IdEtiqueta { get; set; }
        public string NomeEtiqueta { get; set; }
    }
    public class CategoriaAdminPostagens
    {
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
    }
    public class AutoresAdminPostagens
    {
        public int IdAutor { get; set; }
        public string NomeAutor { get; set; }
    }


}