﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog.Models;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Postagem;
using Blog.Models.Blog.Etiqueta;
using Blog.ViewModels.Home;
using Blog.Models.Blog.Postagem.Revisao;
using Blog.Models.Blog.Autor;

namespace Blog.RequestModels.AdminEtiquetas
{
    public class AdminEtiquetasEditarRequestModel
    {
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
    }
}
