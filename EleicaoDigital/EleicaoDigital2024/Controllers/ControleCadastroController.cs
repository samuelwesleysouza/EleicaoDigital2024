using EleicaoDigitalAplication.Services;
using EleicaoRepository;
using EleicaoRepository.ModelsTabelaSql;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq;

namespace EleicaoDigital2024.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ControleCadastroBairroController : ControllerBase
    {
        private readonly EleicaoContext _context;
        private readonly ControleCadastroService _controlebairrosService;

        public ControleCadastroBairroController(EleicaoContext context, ControleCadastroService controleCadastroService)
        {
            _context = context;
            _controlebairrosService = controleCadastroService;
        }

        [HttpPost]
        public IActionResult ControleCadastroBairro([FromQuery] String bairro)
        {
            var listaObjetoBairro = _controlebairrosService.ObterControleCadastroBairro(bairro);
            if (listaObjetoBairro == null)
            {
                return BadRequest();
            }
            else
            {
                var listaResumidaBairros = listaObjetoBairro.Count;
                var usuariosSimplificados = listaObjetoBairro.Select(TabUsuario => new
                {
                    id = TabUsuario.id,
                    usuario = TabUsuario.usuario,
                    telefone = TabUsuario.telefone,
                    instagram = TabUsuario.instagram,
                    bairro = TabUsuario.bairro,
                    lider = TabUsuario.lider,
                }).ToList();
                var response = new
                {
                    quantidadeBairrosCadastrado = listaResumidaBairros,
                    usuarios = usuariosSimplificados
                };
                return Ok(response);
            }
        }

        [HttpGet]
        [Route("controlecadastrolider")]
        public IActionResult ControleCadastroLideranca([FromQuery] string lider)
        {
            var listaObjetoLider = _controlebairrosService.ObterControleCadastroLideranca(lider);
            if (listaObjetoLider == null)
            {
                return BadRequest();
            }
            else
            {
                var listaResumida = listaObjetoLider.Count();
                var usuariosSimplificados = listaObjetoLider.Select(TabUsuario => new
                {
                    id = TabUsuario.id,
                    usuario = TabUsuario.usuario,
                    telefone = TabUsuario.telefone,
                    instagram = TabUsuario.instagram,
                    bairro = TabUsuario.bairro,
                    lider = TabUsuario.lider,
                }).ToList();
                var response = new
                {
                    quantidadePessoasCadastrada = listaResumida,
                    usuarios = usuariosSimplificados
                };
                return Ok(response);
            }
        }
    }
}




