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
using Microsoft.AspNetCore.Authorization;
using Blog.ViewModels.Admin;

namespace Blog.Controllers.Admin
{
    [Authorize]
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
            public IActionResult Listar()
            {
            AdminAutoresListarViewModel model = new AdminAutoresListarViewModel();

            // Obter os autores
            var listaAutores = _autoresOrmService.ObterAutores();

            // Alimentar o model com os autores que serão listadas
            foreach (var autorEntity in listaAutores)
            {
                var autorAdminAutores = new AutorAdminAutores();
                autorAdminAutores.IdAutor = autorEntity.Id;
                autorAdminAutores.NomeAutor = autorEntity.Nome;

                model.Autores.Add(autorAdminAutores);
            }

                return View(model);
        }

            [HttpPost]

            public IActionResult Criar()
            {
                AdminAutoresCriarViewModel model = new AdminAutoresCriarViewModel();
                // Definir possível erro de processamento (vindo do post do criar)
                model.Erro = (string)TempData["erro-msg"];

                return View(model);
            }

            [HttpPost]
            [Route("admin/autores/editar/{id}")]
            public IActionResult Editar(int id)
            {
                AdminAutoresEditarViewModel model = new AdminAutoresEditarViewModel();
                var autorr = _autoresOrmService.ObterAutorPorId(id);
                model.IdAutor = autorr.Id.ToString();
                model.Nome = autorr.Nome;
                return View(model);
        }

            [HttpPost]
            [Route("admin/autores/remover/{id}")]
            public IActionResult Remover(int id)
            {
                AdminAutoresCriarViewModel model = new AdminAutoresCriarViewModel();
            var autorARemover = _autoresOrmService.ObterAutorPorId(id);
            if (autorARemover == null)
            {
                return RedirectToAction("Listar");
            }

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

            // Alimentar o model com os dados da etiqueta a ser editada
                model.IdAutor = autorARemover.Id.ToString();
                model.Nome = autorARemover.Nome;



            return View(model);
            }
        
    }
}
