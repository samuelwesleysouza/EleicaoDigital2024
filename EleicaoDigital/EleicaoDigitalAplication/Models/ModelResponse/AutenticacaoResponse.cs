using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleicaoDigitalAplication.Models.ModelResponse
{
    public class AutenticacaoResponse
    {
        public string token { get; set; }

        public int UsuarioId { get; set; }
    }
}
