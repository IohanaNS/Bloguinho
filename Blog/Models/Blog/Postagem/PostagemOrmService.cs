using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Postagem.Revisao;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models.Blog.Postagem
{
    public class PostagemOrmService
    {
        private readonly DatabaseContext _databaseContext;

        public PostagemOrmService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<PostagemEntity> ObterPostagens()
        {
            return _databaseContext.Postagens
                .Include(p => p.Categoria)
                .Include(p => p.Revisoes)
                .Include(p => p.Comentarios)
                .ToList();
        }


        public List<PostagemEntity> ObterPostagensPopulares()
        {
            return _databaseContext.Postagens
                .Include(a => a.Autor)
                .OrderByDescending(c => c.Comentarios.Count)
                .Take(4)
                .ToList();
        }
        public int UltimaVersaoRevisao(int postagemId)
        {
            var revisao = _databaseContext.Postagens
              .Include(r => r.Revisoes)
              .Where(p => p.Id == postagemId)
              .Select(p => p.Revisoes.OrderByDescending(r => r.Versao).Last())
              .FirstOrDefault();

            if (revisao == null)
                return 0;

            return revisao.Versao;
        }
        public PostagemEntity CriarPostagem(string descricao,CategoriaEntity categoria,string titulo,AutorEntity autor)
        {
            var novaPostagem = new PostagemEntity { Descricao = descricao, Categoria = categoria, Titulo = titulo, Autor =autor };
            _databaseContext.Postagens.Add(novaPostagem);
            _databaseContext.SaveChanges();

            return novaPostagem;
        }

        public PostagemEntity EditarPostagem(int id,string titulo,string descricao,int idCategoria,string texto,DateTime dataExibicao)
        {
            var postagem = _databaseContext.Postagens.Find(id);

            if (postagem == null)
            {
                throw new Exception("Postagem não encontrada!");
            }

            postagem.Descricao = descricao;
            _databaseContext.SaveChanges();




            var revisao = new RevisaoEntity
            {
                Texto = descricao,
                DataCriacao = DateTime.Now,
                Versao = this.UltimaVersaoRevisao(id) + 1,
            };

            postagem.Revisoes.Add(revisao);
            _databaseContext.SaveChanges();

            return postagem;



        }

        public bool RemoverPostagem(int id)
        {
            var postagem = _databaseContext.Postagens.Find(id);

            if (postagem == null)
            {
                throw new Exception("Postagem não encontrada!");
            }

            _databaseContext.Postagens.Remove(postagem);
            _databaseContext.SaveChanges();

            return true;
        }

        internal PostagemEntity ObterPostagemPorId(int id)
        {
            PostagemEntity p = _databaseContext.Postagens.Find(id);

            return p;
        }
    }
}