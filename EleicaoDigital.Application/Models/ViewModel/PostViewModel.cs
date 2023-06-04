using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleicaoDigital.Application.Models.ViewModel
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string? TituloPost { get; set; }
        public string? Texto { get; set; }
        public string?  NomeUsuarioCriacao { get; set; }
        public string? CaminhoArquivoPost { get; set; }
    }
}
