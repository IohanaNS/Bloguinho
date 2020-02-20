using Blog.Models.Blog.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Revisao
{
    public class RevisaoEntity
    {
        public PostagemEntity Postagem { get; set; }

        public String Texto { get; set; }

        public int Versao { get; set; }

        public DateTime Data { get; set; }

        

    }
}
