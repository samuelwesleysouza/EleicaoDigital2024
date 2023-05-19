using EleicaoDigitalAplication.Models.ModelRequest;
using EleicaoDigitalAplication.Models.ModelResponse;
using EleicaoDigitalAplication.Services;
using EleicaoRepository;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Linq;



namespace EleicaoDigital2024.Controllers
{
   
        [ApiController]
        [Route("[controller]")]
        public class EleicaoCadastro : ControllerBase
        {
            private readonly EleicaoContext _context;

            public EleicaoCadastro(EleicaoContext context)
            {
                _context = context;
            }

            [HttpPost]
            [Route("CadastroUsuario")]
            public CadastroResponse SalvarDadosCadastrais([FromBody] CadastroRequest request)
            {
                try
                {
                    var pessoaService = new EleicoesCadastroService(_context);
                    var usuario = pessoaService.SalvarDadosCadastrais(request);
                    return usuario;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }


            [HttpGet]
            [Route("ObterUsuario/{email}")]
            public IActionResult ObterUsuario(string email)
            {
                var usuarioService = new EleicoesCadastroService(_context);
                var usuario = usuarioService.ObterUsuario(email);
                if (usuario == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(usuario);
                }
            }
        }
    }

