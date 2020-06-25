﻿using System;
using System.Collections.Generic;

namespace Blog.ViewModels.Admin
{
    public class AdminPostagensListarViewModel : ViewModelAreaAdministrativa
    {

        public ICollection<PostagemAdminPostagens> Postagens { get; set; }
        public AdminPostagensListarViewModel()
        {
            TituloPagina = "Postagens - Administrador";
            Postagens = new List<PostagemAdminPostagens>();
        }
    }
    public class PostagemAdminPostagens
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
    }
}