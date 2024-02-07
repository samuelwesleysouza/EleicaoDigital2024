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

        /// <summary>
        /// Endpoint para realizar login de usuário.
        /// </summary>
        /// <param name="request">Dados de login do usuário.</param>
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

        /// <summary>
        /// Endpoint para criar um novo usuário.
        /// </summary>
        /// <param name="request">Dados do novo usuário a ser criado.</param>
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

        /// <summary>
        /// Endpoint para obter todos os usuários.
        /// </summary>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Route("all")]
        public ActionResult<List<UsuarioViewModel>> ObterTodos()
        {
            var usuarios = _usuarioService.ObterTodos();

            if (!usuarios.Any())
                return NotFound(new { message = "Usuários não encontrados" });

            return Ok(usuarios);
        }

        /// <summary>
        /// Endpoint para obter usuários por bairro ou líder.
        /// </summary>
        /// <param name="bairro">Nome do bairro.</param>
        /// <param name="lider">ID do líder (opcional).</param>
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

        /// <summary>
        /// Endpoint para obter a quantidade de cadastros feitos por um líder.
        /// </summary>
        /// <param name="bairro">Nome do bairro (opcional).</param>
        /// <param name="lider">ID do líder (opcional).</param>
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Route("quantidade-cadastro-lider")]
        public ActionResult<int> ObterQuantidadeCadastroLider(string bairro = null, int? lider = null)
        {
            if (bairro != null && lider != null)
            {
                // Se ambos os parâmetros forem fornecidos, você pode optar por lidar com isso da maneira que preferir,
                // como retornar um erro ou simplesmente ignorar um deles.
                return Ok("nenhum lider encontrado");
            }

            var quantidade = _usuarioService.ObterQuatidadedeCadastoLider(bairro, lider);
            return Ok(quantidade);
        }


    }
}
