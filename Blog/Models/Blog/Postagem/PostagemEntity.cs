using Blog.Models.Blog.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem
{
    public class PostagemEntity
    {
        private string titulo;
        private AutorEntity autor;

        public string Titulo { get => titulo; set => titulo = value; }
        public AutorEntity Autor { get => autor; set => autor = value; }

        public virtual string editar()
        {
            return "edição realizada";
        }

        public class PostagemSobreFilmeEntity : PostagemEntity
        {
            public string Genero { get; set; }

            public override string editar()
            {
                return "edição realizada na postagem sobre filmes";
            }
        }

    }
}
