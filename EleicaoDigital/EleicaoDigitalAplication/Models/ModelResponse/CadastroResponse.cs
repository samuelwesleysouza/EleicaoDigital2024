using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleicaoDigitalAplication.Models.ModelResponse
{
    public class CadastroResponse
    {
        public string nome { get; set; }

        public string email { get; set; }

        public string mensagem { get; set; }


        public string? usuario { get; set; }

    }
}
