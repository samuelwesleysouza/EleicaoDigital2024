using EleicaoDigital.Application.Models.InputModel;
using EleicaoDigital.Application.Models.ViewModel;
using EleicaoDigital.Repository.Entities;
using EleicaoDigital.Repository.Repository.PostUsuario;

namespace EleicaoDigital.Application.Services.PostUsuario
{
    public class PostsUsuarioService : IPostsUsuarioService
    {
        private readonly IPostsUsuarioRepository _postsUsuarioRepository;
        public PostsUsuarioService(IPostsUsuarioRepository postsUsuarioRepository)
        {
            _postsUsuarioRepository = postsUsuarioRepository;
        }
        public bool AtualizarPost(PostRequest updatedPost, int usarioId)
        {
            return _postsUsuarioRepository.AtualizarPost(new tabPostUsuario
            {
            });
        }

        public PostViewModel InserirNovoPost(PostRequest newPost, int usuarioId)
        {
            var postResult = _postsUsuarioRepository.InserirNovoPost(new tabPostUsuario
            {
                CaminhoArquivoPost = newPost.Files.FileName,
                DataPost = DateTime.Now,
                UsuarioCriacaoId = usuarioId
            });

            var postView = new PostViewModel {
                Id = postResult.Id,
                TituloPost = postResult.TituloPost,
                Texto = postResult.Texto,
                CaminhoArquivoPost = postResult.CaminhoArquivoPost,
                NomeUsuarioCriacao = null //postResult.Usuario.UserName
            };

            return postView;
        }

        public List<PostViewModel> ObterPost()
        {
            return _postsUsuarioRepository.ObterPost().Select(p => new PostViewModel
            {
                Id = p.Id,
                TituloPost = p.TituloPost,
                Texto = p.Texto,
                CaminhoArquivoPost = p.CaminhoArquivoPost,
                NomeUsuarioCriacao = string.Empty //.Usuario.UserName

            }).ToList();
        }

        public bool RemoverPost(int id)
        {
            return _postsUsuarioRepository.RemoverPost(id);
        }
    }
}
