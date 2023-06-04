using EleicaoDigital.Application.Models.InputModel;
using EleicaoDigital.Application.Services.PostUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EleicaoDigital2024.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostsUsuariosController : ControllerBase
    {
        private readonly IPostsUsuarioService _postUsuarioService;

        public PostsUsuariosController(IPostsUsuarioService postUsuarioService)
        {
            _postUsuarioService = postUsuarioService;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult InserirNovoPost([FromBody] PostRequest request)
        {
            var usuarioId = Convert.ToInt32(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            var newPost = _postUsuarioService.InserirNovoPost(request, usuarioId);

            return NoContent();
        }

        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult ObterTodosPosts()
        {
            var allPosts = _postUsuarioService.ObterPost();

            if (!allPosts.Any())
                return NotFound(new { message = "Nenhum post encontrado." });

            return Ok(allPosts);
        }

        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult AtualizarPostUsuario([FromBody] PostRequest request)
        {
            var usuarioId = Convert.ToInt32(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            var newPost = _postUsuarioService.AtualizarPost(request, usuarioId);

            return NoContent();
        }

        [HttpDelete("id")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "admin")]
        public ActionResult RemoverPost([FromRoute] int id)
        {
            var result = _postUsuarioService.RemoverPost(id);

            if (!result)
                return BadRequest(new { message = "Não foi possivel remover esse post" });

            return Ok();
        }
    }
}
