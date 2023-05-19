using EleicaoDigitalAplication.Models.ModelRequest;
using EleicaoDigitalAplication.Services;
using EleicaoRepository;
using EleicaoRepository.ModelsTabelaSql;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace EleicaoDigital2024.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostImgVideosController : ControllerBase
    {
        private readonly EleicaoContext _context;

        public PostImgVideosController(EleicaoContext context)
        {
            _context = context;
        }

        [HttpPost("upload")]
        public IActionResult Add([FromForm] PostMidiaRequest postMidia)
        {
            var storagePath = Path.Combine(Directory.GetCurrentDirectory(), "Storage");
            if (!Directory.Exists(storagePath))
            {
                Directory.CreateDirectory(storagePath);
            }

            var filePath = Path.Combine(storagePath, postMidia.Photo.FileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            postMidia.Photo.CopyTo(fileStream);

            var employee = new TabelaEmployee()
            {
                Name = postMidia.Name,
                idUsuario = postMidia.idUsuario,
                Photo = filePath
            };
            _context.TabelaEmployee.Add(employee);
            _context.SaveChanges();

            return Ok();
        }
    }
}
