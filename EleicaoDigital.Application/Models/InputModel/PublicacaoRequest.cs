

namespace EleicaoDigital.Application.Models.InputModel
{
    public record PublicacaoRequest
    {
        public int? Id { get; set; }
        public string? Titulo { get; set; }
        public string? Texto { get; set; }
        public string? UrlsImagemPublicacao { get; set; }
        public string? PublicacaoTipo { get; set; }
        public int UsuarioDonoPublicacao { get; set; }
        public int Hierarquia { get; set; }
    }
}
