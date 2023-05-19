using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleicaoRepository.ModelsTabelaSql
{
    public class TabPostUsuario
    { 
        public int id { get; set; }     
        public string nome { get; set; }
        public string text { get; set; }
        public DateTime datapost { get; set; }
    }
}
