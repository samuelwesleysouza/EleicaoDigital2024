using EleicaoDigital.Application.Models.InputModel;
using EleicaoDigital.Application.Services.Publicacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EleicaoDigital2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacaoController : ControllerBase
    {
        private readonly IPublicacaoService _publicService;
        public PublicacaoController(IPublicacaoService publicService)
        {
            _publicService = publicService;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult CriaPublicacao([FromBody] PublicacaoRequest request)
        {
            var usuarioCriacao = Convert.ToInt32(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            var publicacao = _publicService.CriarPublicacao(request, usuarioCriacao);

            if (publicacao is null)
                return BadRequest(new { message = "Erro ao criar sua publicação. Contate o administrador" });

            return Ok(publicacao);
        }

        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult EditaPublicacao([FromBody] PublicacaoRequest request)
        {
            var usuarioAtualizacao = Convert.ToInt32(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            var publicacao = _publicService.EditarPublicacao(request, usuarioAtualizacao);

            if (publicacao is null)
                return BadRequest(new { message = "Erro ao editar sua publicação. Contate o administrador" });

            return Ok(publicacao);
        }

        [HttpDelete("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public ActionResult ApagaPublicacao(int id)
        {
            var retorno = _publicService.ApagarPublicacao(id);

            if (!retorno)
                return BadRequest(new { message = "Erro ao editar sua publicação.Contate o administrador" });
            else
                return Ok();
        }

        [HttpGet("{usuarioCodigo}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize]
        public ActionResult ObterPublicacaoPadrao(int usuarioCodigo)
        {
            var publicacao = _publicService.ObterPublicacaoPadrao(usuarioCodigo);

            if (publicacao is null)
                return NotFound(new { message = "Nenhuma publicação encontrada." });

            return Ok(publicacao);
        }

        [HttpGet("{tipoPublicacao/usuarioCodigo}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize]
        public ActionResult ObterPublicacaoPorTipoEUsuario(string tipoPublicacao, int usuarioCodigo)
        {
            var publicacao = _publicService.ObterPublicacaoPorTipoEUsuario(tipoPublicacao, usuarioCodigo);

            if (publicacao is null)
                return NotFound(new { message = "Nenhuma publicação encontrada." });

            return Ok(publicacao);
        }
    }
}
