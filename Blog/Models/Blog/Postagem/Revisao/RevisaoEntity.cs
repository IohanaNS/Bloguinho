using Blog.Models.Blog.Autor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Revisao
{
    public class RevisaoEntity
    {
        [Key]
        public int Id { get; set; }
        public PostagemEntity Postagem { get; set; }

        public String Texto { get; set; }

        public int Versao { get; set; }

        public DateTime Data { get; set; }

        

    }
}
