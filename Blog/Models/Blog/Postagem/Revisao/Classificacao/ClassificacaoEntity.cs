﻿using Blog.Models.Blog.Autor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models.Blog.Postagem.Revisao.Classificacao
{
    public class ClassificacaoEntity
    {   
        [Key]
        public int Id { get; set; }
        public RevisaoEntity Revisao { get; set; }
        public bool Joinha { get; set; }

       
    }
}
