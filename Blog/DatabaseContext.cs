using Blog.Models.Blog.Autor;
using Blog.Models.Blog.Categoria;
using Blog.Models.Blog.Postagem;
using Blog.Models.Blog.Postagem.Revisao;
using Blog.Models.Blog.Postagem.Revisao.Classificacao;
using Blog.Models.Blog.Postagem.Revisao.Comentario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog
{
    public class DatabaseContext : DbContext {


        public DbSet<CategoriaEntity> Categoria { get; set; }
        public DbSet<PostagemEntity> Postagem { get; set; }
        public DbSet<RevisaoEntity> Revisao { get; set; }
        public DbSet<ClassificacaoEntity> Classificacao { get; set; }
        public DbSet<ComentarioEntity> Comentario { get; set; }
        public DbSet<AutorEntity> Autor { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("Server=localhost;User Id=root;password=Pow4r*++;Database=bloguinho");
        }
        
            

    }
}
