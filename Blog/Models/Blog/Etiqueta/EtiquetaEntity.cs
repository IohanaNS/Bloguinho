using Blog.Models.Blog.Autor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Etiqueta
{ 
    public class EtiquetaEntity
    {
        [Key]
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Cor { get; set; }
    }
}
