using EleicaoDigitalAplication.Autenticacao;
using EleicaoDigitalAplication.Models.ModelRequest;
using EleicaoRepository;
using Microsoft.AspNetCore.Mvc;

namespace EleicaoDigital2024.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AutenticationsController : ControllerBase
    {
        private readonly EleicaoContext _context;
        public AutenticationsController(EleicaoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login([FromBody] AutenticacaoRequest request) //Nosso método junto a classe AutenticacaoRequest
        {
            var autenticacaoService = new AutenticacaoServices(_context);
            var resposta = autenticacaoService.Autenticar(request);

            if (resposta == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(resposta);
            }
        }

    }
}



