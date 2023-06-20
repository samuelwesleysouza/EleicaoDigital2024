
using EleicaoDigital.Repository.Entities;

namespace EleicaoDigital.Repository.Repository.Publicacao
{
    public interface IPublicacaoRepository
    {
        tabPublicacao CriarPublicacao(tabPublicacao publicacao);
        tabPublicacao EditarPublicacao(tabPublicacao publicacao);
        bool ApagarPublicacao(int publicacaoCodigo);
        tabPublicacao ObterPublicacaoPadrao(int publicacaoCodigo);
        List<tabPublicacao>? ObterPublicacaoPorTipoEUsuario(string tipoPublicacao, int usuarioCodigo);
    }
}
