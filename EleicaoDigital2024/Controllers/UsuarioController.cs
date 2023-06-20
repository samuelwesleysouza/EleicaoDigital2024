using EleicaoDigital.Application.Models.InputModel;
using EleicaoDigital.Application.Models.ViewModel;
using EleicaoDigital.Application.Services.Usuario;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EleicaoDigital2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
       
        
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Route("login")]
        public ActionResult<UsuarioLoginViewModel> Login([FromBody] LoginRequest request)
        {
            var usuario = _usuarioService.Login(request.Email, request.Password);

            if (string.IsNullOrEmpty(usuario.Token))
                return NotFound(usuario);

            return Ok(usuario);
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<UsuarioLoginViewModel> CriarUsuario([FromBody] UsuarioRequest request)
        {
            var usuarioLiderCriacao = Convert.ToInt32(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            var usuario = _usuarioService.CadastrarUsuario(request, usuarioLiderCriacao);

            if (string.IsNullOrEmpty(usuario.Token))
                return BadRequest(new { message = "Erro ao cadastrar usuário. Contate o administrador" });

            return Ok(usuario);
        }

        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Route("all")]
        public ActionResult<List<UsuarioViewModel>> ObterTodos()
        {
            var usuarios = _usuarioService.ObterTodos();

            if (!usuarios.Any())
                return NotFound(new { message = "Usuários não encontrado" });

            return Ok(usuarios);
        }

        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult<List<UsuarioViewModel>> ObterPorBairroOuLider(string bairro, int? lider = null)
        {
            var usuarios = _usuarioService.ObterPorBairroOuLider(bairro, lider);

            if (!usuarios.Any())
                return NotFound(new { message = "Usuários não encontrados" });

            return Ok(usuarios);
        }
    }
}
