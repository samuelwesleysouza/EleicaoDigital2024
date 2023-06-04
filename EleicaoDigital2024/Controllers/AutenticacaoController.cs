using EleicaoDigital.Application.Models.InputModel;
using EleicaoDigital.Application.Services.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace EleicaoDigital2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public AutenticacaoController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult Login([FromBody] LoginRequest request)
        {
            var usuario = _usuarioService.Login(request.Email, request.Password);

            if (string.IsNullOrEmpty(usuario.Token))
                return NotFound(usuario);

            return Ok(usuario);
            
        }
    }
}
