using EleicaoDigital.Application.Models.InputModel;
using EleicaoDigital.Application.Models.ViewModel;

namespace EleicaoDigital.Application.Services.Usuario
{
    public interface IUsuarioService
    {
        UsuarioLoginViewModel Login(string email, string password);
        UsuarioLoginViewModel CadastrarUsuario(UsuarioRequest usuarioRequest, int usuarioLiderCadastro);
        UsuarioViewModel ObterUsuarioPorEmail(string email);
        List<UsuarioViewModel> ObterTodos();
        List<UsuarioViewModel> ObterPorBairroOuLider(string bairro, int? lider);
        string GerarTokenJwt(UsuarioViewModel usuario, string role);
    }
}
