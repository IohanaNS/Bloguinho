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
using Blog.RequestModels.AdminCategorias;
using Blog.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;

namespace Blog.Controllers.Admin
{

    [Authorize]
    public class AdminCategoriasController : Controller
    {
        private readonly CategoriaOrmService _categoriaOrmService;

        public AdminCategoriasController(
            CategoriaOrmService categoriaOrmService
        )
        {
            _categoriaOrmService = categoriaOrmService;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            AdminCategoriasListarViewModel model = new AdminCategoriasListarViewModel();
           

            // Obter as cat
            var lista = _categoriaOrmService.ObterCategorias();
            

            return View(model);
        }

        [HttpGet]
        public IActionResult Detalhar(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Criar()
        {
            AdminCategoriasCriarViewModel model = new AdminCategoriasCriarViewModel();

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

           

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Criar(AdminCategoriasCriarRequestModel request)
        {
            var nome = request.Nome;

            try
            {
                _categoriaOrmService.CriarCategoria(nome);
            }
            catch (Exception exception)
            {
                TempData["erro-msg"] = exception.Message;
                return RedirectToAction("Criar");
            }

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            AdminCategoriasEditarViewModel model = new AdminCategoriasEditarViewModel();

            // Obter cat a editar
            var cat = _categoriaOrmService.ObterCategoriaPorId(id);
            if (cat == null)
            {
                return RedirectToAction("Listar");
            }

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

           

            // Alimentar o model com os dados da cat a ser editada
            model.IdCategoria = cat.Id;
            model.Nome = cat.Nome;


            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Editar(AdminCategoriasEditarRequestModel request)
        {
            var id = request.Id;
            var nome = request.Nome;

            try
            {
                _categoriaOrmService.EditarCategoria(id, nome);
            }
            catch (Exception exception)
            {
                TempData["erro-msg"] = exception.Message;
                return RedirectToAction("Editar", new { id = id });
            }

            return RedirectToAction("Listar");
        }

        [HttpGet]
        public IActionResult Remover(int id)
        {
            AdminCategoriasEditarViewModel model = new AdminCategoriasEditarViewModel();

            // Obter cat a editar
            var cat = _categoriaOrmService.ObterCategoriaPorId(id);
            if (cat == null)
            {
                return RedirectToAction("Listar");
            }

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

            // Alimentar o model com os dados da cat a ser editada
            model.IdCategoria = cat.Id;
            model.Nome = cat.Nome; ;

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Remover(AdminCategoriasRemoverRequestModel request)
        {
            var id = request.Id;

            try
            {
                _categoriaOrmService.RemoverCategoria(id);
            }
            catch (Exception exception)
            {
                TempData["erro-msg"] = exception.Message;
                return RedirectToAction("Remover", new { id = id });
            }

            return RedirectToAction("Listar");
        }
    }
} 
    