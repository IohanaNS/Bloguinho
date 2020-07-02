using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Autor
{
    public class AutorEntity { 


        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]

        public string Nome { get;set; }

    }
}
