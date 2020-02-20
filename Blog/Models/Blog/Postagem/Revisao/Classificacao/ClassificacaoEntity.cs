using Blog.Models.Blog.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Revisao.Classificacao
{
    public class ClassificacaoEntity
    {
        public RevisaoEntity Revisao { get; set; }
        public bool Joinha { get; set; }

       
    }
}
