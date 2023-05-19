﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleicaoRepository.ModelsTabelaSql
{
    public class TabUsuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string usuario { get; set; }
        public string senha { get; set; }
        public string role { get; set; }
        public string email { get; set; }
        public string instagram { get; set; }
        public string telefone { get; set; }
        public string bairro { get; set; }
        public int quantidade { get; set; }
        public string lider { get; set; }
        public DateTime datacadastro { get; set; }

    }

}
