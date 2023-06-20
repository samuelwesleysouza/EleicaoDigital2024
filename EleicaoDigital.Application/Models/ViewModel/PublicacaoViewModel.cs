
namespace EleicaoDigital.Application.Models.ViewModel
{
    public record PublicacaoViewModel
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Texto { get; set; }
        public string? PublicacaoTipo { get; set; }
        public DateTime DataPublicacao { get; set; }
    }
}
