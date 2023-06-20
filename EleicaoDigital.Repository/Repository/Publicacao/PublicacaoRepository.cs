
using EleicaoDigital.Repository.Entities;

namespace EleicaoDigital.Repository.Repository.Publicacao
{
    public class PublicacaoRepository : IPublicacaoRepository
    {
        public Context _context { get; }
        public PublicacaoRepository(Context context)
        {
            _context = context;
        }
        public tabPublicacao CriarPublicacao(tabPublicacao publicacao)
        {
            _context.tabPublicacao.Add(publicacao);
            _context.SaveChanges();

            return publicacao;
        }
        public tabPublicacao EditarPublicacao(tabPublicacao publicacao)
        {
            _context.tabPublicacao.Update(publicacao);
            _context.SaveChanges();

            return publicacao;
        }
        public bool ApagarPublicacao(int publicacaoCodigo)
        {
            var publicacao = _context.tabPublicacao.FirstOrDefault(p => p.Codigo == publicacaoCodigo);

            if (publicacao is null)
                return false;

            _context.Remove(publicacao);
            _context.SaveChanges();

            return true;
        }
        public tabPublicacao ObterPublicacaoPadrao(int usuarioCodigo)
        {
            return _context.tabPublicacao.FirstOrDefault(p => p.UsuarioDonoPublicacao == usuarioCodigo && p.Hierarquia == 1);
        }
        public List<tabPublicacao>? ObterPublicacaoPorTipoEUsuario(string tipoPublicacao, int usuarioCodigo)
        {
            return _context.tabPublicacao.Where(p => p.PublicacaoTipo == tipoPublicacao && p.UsuarioDonoPublicacao == usuarioCodigo).ToList();
        }
    }
}

