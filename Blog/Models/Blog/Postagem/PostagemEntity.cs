using Blog.Models.Blog.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem
{
    public class PostagemEntity
    {

        public String Titulo { get; set; }
        public AutorEntity Autor { get; set; }
        public List<EtiquetaEntity> Etiquetas;
        public List<RevisaoEntity> Revisoes;


    }
}
