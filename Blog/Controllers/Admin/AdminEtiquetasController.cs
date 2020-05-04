﻿using Blog.Models.Blog.Etiqueta;
using Blog.RequestModels.AdminCategorias;
using Blog.RequestModels.AdminEtiquetas;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers.Admin
{
    public class AdminEtiquetasController : Controller
    {
        private readonly EtiquetaOrmService _EtiquetaOrmService;


        public AdminEtiquetasController(
            EtiquetaOrmService EtiquetaOrmService
        )
        {
            _EtiquetaOrmService = EtiquetaOrmService;
        }


        [HttpGet]
        public IActionResult Listar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Detalhar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Criar()
        {
            ViewBag.erro = TempData["erro-msg"];

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Criar(AdminEtiquetasCriarRequestModel request)
        {
            var nome = request.Nome;
            var categoria = request.Categoria;

            try
            {
                _EtiquetaOrmService.CriarEtiqueta(nome,categoria);
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
            ViewBag.id = id;
            ViewBag.erro = TempData["erro-msg"];

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Editar(AdminEtiquetasEditarRequestModel request)
        {
            var id = request.Id;
            var nome = request.Nome;

            try
            {
                _EtiquetaOrmService.EditaEtiqueta(id, nome);
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
            ViewBag.id = id;
            ViewBag.erro = TempData["erro-msg"];

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Remover(AdminEtiquetasRemoverRequestModel request)
        {
            var id = request.Id;

            try
            {
                _EtiquetaOrmService.RemoverEtiqueta(id);
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
