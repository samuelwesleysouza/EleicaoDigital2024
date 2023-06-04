using Microsoft.AspNetCore.Http;

namespace EleicaoDigital.Application.Models.InputModel
{
    public class PostRequest
    {
        public int? Id { get; set; }
        public IFormFile? Files { get; set; }
    }
}
