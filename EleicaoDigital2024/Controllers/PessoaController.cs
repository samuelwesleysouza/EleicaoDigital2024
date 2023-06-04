using EleicaoDigital.Application.Models.InputModel;
using EleicaoDigital.Application.Services.Pessoa;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EleicaoDigital2024.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "admin,lider")]
        public ActionResult CadastraPessoa([FromBody] PessoaRequest request)
        {
            var usuarioId = Convert.ToInt32(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);

            var pessoaView = _pessoaService.CadastraPessoa(request, usuarioId);

            if (pessoaView == null)
                return BadRequest(new { message = "Erro ao cadastrar pessoa." });

            return Created(nameof(GetPessoas), pessoaView);
        }

        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "admin,lider")]
        public ActionResult AtualizaPessoa([FromBody] PessoaRequest request)
        {
            var usuarioId = Convert.ToInt32(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);

            var pessoaView = _pessoaService.AtualizaPessoa(request, usuarioId);

            if (!pessoaView)
                return BadRequest(new { message = "Erro ao atualizar cadastro." });

            return Ok(new {message = "Alterado com sucesso."});
        }

        [HttpDelete("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "admin,lider")]
        public ActionResult RemovePessoa(int id)
        {
            var result = _pessoaService.RemovePessoa(id);

            if (!result)
                return BadRequest(new { message = "Erro ao remover cadastro." });

            return Ok();
        }

        [HttpGet("bairro/{nomeBairro}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "admin,lider")]
        public ActionResult GetPessoaPorBairro(string nomeBairro)
        {
            var pessoas = _pessoaService.ObterPessoasPorBairro(nomeBairro);

            if (!pessoas.Any())
                return NotFound(new { message = "Nenhuma pessoa encontrada para esse bairro" });

            return Ok(pessoas);
        }

        [HttpGet("lider")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "admin,lider")]
        public ActionResult GetPessoaPorLider()
        {
            var usuarioId =  Convert.ToInt32(((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            var pessoas = _pessoaService.ObterPessoasPorLiderId(usuarioId);

            if (!pessoas.Any())
                return NotFound(new { message = "Nenhuma pessoa encontrada para esse líder." });

            return Ok(pessoas);
        }


        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "admin")]
        public ActionResult GetPessoas()
        {
            var pessoas = _pessoaService.ObterPessoas();

            if (!pessoas.Any())
                return NotFound(new { message = "Nenhuma pessoa encontrada." });

            return Ok(pessoas);
        }
    }
}
