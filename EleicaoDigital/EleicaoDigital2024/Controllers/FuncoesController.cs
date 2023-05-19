using EleicaoDigitalAplication.Models.ModelRequest;
using EleicaoDigitalAplication.Services;
using EleicaoRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Azure.Core;

namespace EleicaoDigital2024.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncoesGeraisController : ControllerBase
    {
        private readonly EleicaoContext _context;

        public FuncoesGeraisController(EleicaoContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("InserirPostTexto")]
        public IActionResult InserirPostTexto([FromBody] FuncoesRequest request)
        {
            var funcoesService = new FuncoesService(_context);

            var sucesso = funcoesService.InserirPostTexto(request);

            if (sucesso != null)
            {
                return Ok(sucesso);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("ObterPostTxt")]

        public IActionResult ObterPostTxt()
        {
            var funcoesService = new FuncoesService(_context);

            var sucesso = funcoesService.ObterPostTxt();
            if (sucesso == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(sucesso);
            }
        }


        [HttpPut]
        [Route("AtualizarPostTxt/{id}")]
        public IActionResult AtualizarPostTxt([FromBody] FuncoesRequest text)
        {
            /*  var usuario = Convert.ToInt32((((ClaimsIdentity)User.Identity).Claims.FirstOrDefault(x => x.Type == "usuarioId")?.Value));
             */
            var funcoesService = new FuncoesService(_context);
            var sucesso = funcoesService.AtualizarPostTxt(text);
            var livros = funcoesService.ObterPostTxt();

            if (sucesso == true)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("RemoverPostTxt/{id}")]
        [Authorize]
        [Authorize(Roles = "admin")]
        public IActionResult RemoverPostTxt([FromRoute] int id)
        {
            var removerLivrosService = new FuncoesService(_context);
            var sucesso = removerLivrosService.RemoverPostTxt(id);

            if (sucesso)
            {
                return NoContent(); // Retornar código de status 204 No Content
            }
            else
            {
                return NotFound(); // Retornar código de status 404 Not Found, se necessário
            }
        }
    }
}