using Blog.Models.Blog.Autor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Revisao.Comentario
{
    public class ComentarioEntity
    {
        [Key]
        public int Id { get; set; }
        public RevisaoEntity Revisao { get; set; }
        public String Texto { get; set; }
        public String Autor { get; set; }
        public DateTime Data { get; set; }
    }
}
