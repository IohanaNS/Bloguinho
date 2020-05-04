using System;
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

namespace Blog.Controllers.Admin
{
    public class AdminAutoresController : Controller
    {
        //CRIAR PARA ETIQUETA E POSTAGEM EM ADMIN
      
            private readonly AutorOrmService _autoresOrmService;

            public AdminAutoresController(
                AutorOrmService autoresOrmService
            )
            {
                _autoresOrmService = autoresOrmService;
            }

            [HttpGet]
            [Route("admin/autores")]
            [Route("admin/autores/listar")]
            public string Listar()
            {
                return "listar autores";
            }

            [HttpPost]
            [Route("admin/autores/criar")]
            public string Criar()
            {
                return "criar autor";
            }

            [HttpPost]
            [Route("admin/autores/editar/{id}")]
            public string Editar(int id)
            {
                return "editar autor";
            }

            [HttpPost]
            [Route("admin/autores/remover/{id}")]
            public string Remover(int id)
            {
                return "remover autor";
            }
        
    }
}
