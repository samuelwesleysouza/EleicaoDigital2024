using EleicaoDigital.Application.Models.InputModel;
using EleicaoDigital.Application.Models.ViewModel;

namespace EleicaoDigital.Application.Services.Publicacao
{
    public interface IPublicacaoService 
    {
        PublicacaoViewModel? CriarPublicacao(PublicacaoRequest request,int usuariaoCriacao);
        PublicacaoViewModel? EditarPublicacao(PublicacaoRequest request, int usuarioAtualizacao);
        bool ApagarPublicacao(int publicacaoCodigo);
        PublicacaoViewModel? ObterPublicacaoPadrao(int usuarioCodigo);
        List<PublicacaoViewModel>? ObterPublicacaoPorTipoEUsuario(string tipoPublicacao, int usuarioCodigo);
    }
}
