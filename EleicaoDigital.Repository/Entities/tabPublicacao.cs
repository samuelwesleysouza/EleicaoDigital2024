using EleicaoDigital.Repository.Entities.Base;

namespace EleicaoDigital.Repository.Entities
{
    public class tabPublicacao : BaseEntity
    {
        public string? Titulo { get; set; }
        public string? Texto { get; set; }
        public string? UrlsImagemPublicacao { get; set; }
        public string? PublicacaoTipo { get; set; }
        public int UsuarioDonoPublicacao{ get; set; }
        public int Hierarquia { get; set; }
    }
}
