using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Etiqueta;
using Blog.Models.Blog.Postagem;
using Blog.RequestModels.AdminPostagens;
using Blog.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers.Admin
{
    [Authorize]
    public class AdminPostagensController : Controller
    {
        private readonly PostagemOrmService _postagemOrmService;
        private readonly CategoriaOrmService _categoriaOrmService;
        private readonly EtiquetaOrmService _etiquetaOrmService;

        public AdminPostagensController(
            PostagemOrmService postagemOrmService, CategoriaOrmService categoriaOrmService, EtiquetaOrmService etiquetaOrmService
        )
        {
            _postagemOrmService = postagemOrmService;
            _categoriaOrmService = categoriaOrmService;
            _etiquetaOrmService = etiquetaOrmService;

        }

        [HttpGet]
        public IActionResult Listar()
        {
            AdminPostagensListarViewModel model = new AdminPostagensListarViewModel();

            // Obter as postagens
            var listaPostagens = _postagemOrmService.ObterPostagens();

            // Alimentar o model com as postagens que serão listadas
            foreach (var postagemEntity in listaPostagens)
            {
                var postagemAdmiPostagens = new PostagemAdminPostagens();
                postagemAdmiPostagens.Id = postagemEntity.Id;
                postagemAdmiPostagens.Texto = postagemEntity.Descricao;
                postagemAdmiPostagens.Titulo = postagemEntity.Titulo;

                model.Postagens.Add(postagemAdmiPostagens);
            }

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
            AdminPostagensCriarViewModel model = new AdminPostagensCriarViewModel();

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

            // Obter as Categorias
            var listaCategorias = _categoriaOrmService.ObterCategorias();

            // Alimentar o model com as categorias que serão colocadas no <select> do formulário
            foreach (var categoriaEntity in listaCategorias)
            {
                var categoriaAdminPostagens = new CategoriaAdminPostagens();
                categoriaAdminPostagens.IdCategoria = categoriaEntity.Id;
                categoriaAdminPostagens.NomeCategoria = categoriaEntity.Nome;

                model.Categorias.Add(categoriaAdminPostagens);
            }

            // Obter as etiquetas
            var listaEtiquetas = _etiquetaOrmService.ObterEtiquetas();

            // Alimentar o model com as etiquetas que serão colocadas no <select> do formulário
            foreach (var etiquetaEntity in listaEtiquetas)
            {
                var etiquetaAdminPostagens = new EtiquetasAdminPostagens();
                etiquetaAdminPostagens.IdEtiqueta = etiquetaEntity.Id;
                etiquetaAdminPostagens.NomeEtiqueta = etiquetaEntity.Nome;

                model.Etiquetas.Add(etiquetaAdminPostagens);
            }

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Criar(AdminPostagensCriarRequestModel request)
        {
            var titulo = request.Titulo;
            var descricao = request.Descricao;
            var idAutor = request.IdAutor;
            var idCategoria = request.IdCategoria;
            

            try
            {
                _postagemOrmService.CriarPostagem(descricao, idCategoria, titulo, idAutor);
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
            AdminPostagensEditarViewModel model = new AdminPostagensEditarViewModel();

            // Obter etiqueta a editar
            var postagemAA = _postagemOrmService.ObterPostagemPorId(id);
            if (postagemAA == null)
            {
                return RedirectToAction("Listar");
            }

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];
            // Obter as Categorias
            var listaCategorias = _categoriaOrmService.ObterCategorias();

            // Alimentar o model com as categorias que serão colocadas no <select> do formulário
            foreach (var categoriaEntity in listaCategorias)
            {
                var categoriaAdminPostagens = new CategoriaAdminPostagens();
                categoriaAdminPostagens.IdCategoria = categoriaEntity.Id;
                categoriaAdminPostagens.NomeCategoria = categoriaEntity.Nome;

                model.Categorias.Add(categoriaAdminPostagens);
            }

            // Obter as etiquetas
            var listaEtiquetas = _etiquetaOrmService.ObterEtiquetas();

            // Alimentar o model com as etiquetas que serão colocadas no <select> do formulário
            foreach (var etiquetaEntity in listaEtiquetas)
            {
                var etiquetaAdminPostagens = new EtiquetasAdminPostagens();
                etiquetaAdminPostagens.IdEtiqueta = etiquetaEntity.Id;
                etiquetaAdminPostagens.NomeEtiqueta = etiquetaEntity.Nome;

                model.Etiquetas.Add(etiquetaAdminPostagens);
            }

            // Alimentar o model com os dados da etiqueta a ser editada
     
            model.NomePostagem = postagemAA.Titulo;
            model.IdCategoriaPostagem = postagemAA.Categoria.Id;
            model.IdEtiquetaPostagem = postagemAA.Categoria.Id;
           

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Editar(AdminPostagensEditarRequestModel request)
        {
            var id = request.Id;
            var titulo = request.Titulo;
            var descricao = request.Descricao;
            var idCategoria = Convert.ToInt32(request.IdCategoria);
            var texto = request.Descricao;
            DateTime dataExibicao = request.DataExibicao;

            try
            {
                _postagemOrmService.EditarPostagem(id, titulo, descricao, idCategoria, texto, dataExibicao);
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
            AdminPostagensRemoverViewModel model = new AdminPostagensRemoverViewModel();

            // Obter postagem a remover
            var postagemAA = _postagemOrmService.ObterPostagemPorId(id);
            if (postagemAA == null)
            {
                return RedirectToAction("Listar");
            }

            // Definir possível erro de processamento (vindo do post do criar)
            model.Erro = (string)TempData["erro-msg"];

            // Alimentar o model com os dados da etiqueta a ser editada
            model.IdPostagem = postagemAA.Id;
            model.TituloPostagem = postagemAA.Titulo;
 

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Remover(AdminPostagensRemoverRequestModel request)
        {
            var id = request.Id;

            try
            {
                _postagemOrmService.RemoverPostagem(id);
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
