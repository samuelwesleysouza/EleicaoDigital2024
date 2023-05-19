using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleicaoDigitalAplication.Models.ModelRequest
{
    public class PostMidiaRequest
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int idUsuario { get; set; }

        public IFormFile Photo { get; set; }    
    }
}
