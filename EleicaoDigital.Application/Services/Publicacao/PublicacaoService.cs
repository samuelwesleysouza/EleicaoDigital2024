using EleicaoDigital.Application.Models.InputModel;
using EleicaoDigital.Application.Models.ViewModel;
using EleicaoDigital.Repository.Entities;
using EleicaoDigital.Repository.Repository.Publicacao;

namespace EleicaoDigital.Application.Services.Publicacao
{
    public class PublicacaoService : IPublicacaoService
    {
        private readonly IPublicacaoRepository _publiRepository;

        public PublicacaoService(PublicacaoRepository publiRepository)
        {
            _publiRepository = publiRepository;
        }
        public PublicacaoViewModel? CriarPublicacao(PublicacaoRequest request, int usuariaoCriacao)
        {
            var publicacao = _publiRepository.CriarPublicacao(new tabPublicacao
            {
                Titulo = request.Titulo,
                Texto = request.Texto,
                PublicacaoTipo = request.PublicacaoTipo,
                Hierarquia = request.Hierarquia,
                UrlsImagemPublicacao = request.UrlsImagemPublicacao,
                UsuarioDonoPublicacao = request.UsuarioDonoPublicacao,
                UsuarioCadastroCodigo = usuariaoCriacao,
                DataCadastro = DateTime.Now,
            });

            return new PublicacaoViewModel
            {
                Id = publicacao.Id,
                Titulo = publicacao.Titulo,
                Texto = publicacao.Texto,
                PublicacaoTipo = publicacao.PublicacaoTipo,
                DataPublicacao = publicacao.DataCadastro
            };
        }
        public PublicacaoViewModel? EditarPublicacao(PublicacaoRequest request, int usuarioAtualizacao)
        {
            var publicacao = _publiRepository.EditarPublicacao(new tabPublicacao
            {
                Titulo = request.Titulo,
                Texto = request.Texto,
                PublicacaoTipo = request.PublicacaoTipo,
                Hierarquia = request.Hierarquia,
                UrlsImagemPublicacao = request.UrlsImagemPublicacao,
                UsuarioDonoPublicacao = request.UsuarioDonoPublicacao,
                UsuarioAlteracaoCodigo = usuarioAtualizacao,
                DataUltimaAlteracao = DateTime.Now,
            });

            return new PublicacaoViewModel
            {
                Id = publicacao.Id,
                Titulo = publicacao.Titulo,
                Texto = publicacao.Texto,
                PublicacaoTipo = publicacao.PublicacaoTipo,
                DataPublicacao = publicacao.DataCadastro
            };
        }
        public bool ApagarPublicacao(int publicacaoCodigo)
        {
            return _publiRepository.ApagarPublicacao(publicacaoCodigo);
        }

        public PublicacaoViewModel? ObterPublicacaoPadrao(int usuarioCodigo)
        {
            var publicacao = _publiRepository.ObterPublicacaoPadrao(usuarioCodigo);

            if (publicacao is null)
                return null;

            return new PublicacaoViewModel
            {
                Id = publicacao.Id,
                Titulo = publicacao.Titulo,
                Texto = publicacao.Texto,
                PublicacaoTipo = publicacao.PublicacaoTipo,
                DataPublicacao = publicacao.DataCadastro
            };
        }

        public List<PublicacaoViewModel>? ObterPublicacaoPorTipoEUsuario(string tipoPublicacao, int usuarioCodigo)
        {
            var publicacao = _publiRepository.ObterPublicacaoPorTipoEUsuario(tipoPublicacao, usuarioCodigo);

            if (publicacao is null)
                return null;

            return publicacao.Select(p => new PublicacaoViewModel
            {
                Id = p.Id,
                Titulo = p.Titulo,
                Texto = p.Texto,
                PublicacaoTipo = p.PublicacaoTipo,
                DataPublicacao = p.DataCadastro
            }).ToList();
        }
    }
}
