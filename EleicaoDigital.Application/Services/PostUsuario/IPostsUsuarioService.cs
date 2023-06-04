using EleicaoDigital.Application.Models.InputModel;
using EleicaoDigital.Application.Models.ViewModel;

namespace EleicaoDigital.Application.Services.PostUsuario
{
    public interface IPostsUsuarioService
    {
        PostViewModel InserirNovoPost(PostRequest newPost, int usarioId);
        List<PostViewModel> ObterPost();
        bool AtualizarPost(PostRequest updatedPost, int usarioId);
        bool RemoverPost(int id);
    }
}
