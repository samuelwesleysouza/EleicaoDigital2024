using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EleicaoRepository.ModelsTabelaSql
{
    public class TabelaEmployee
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int idUsuario { get; set; }

        public string Photo { get; set; }

       
    }
}
