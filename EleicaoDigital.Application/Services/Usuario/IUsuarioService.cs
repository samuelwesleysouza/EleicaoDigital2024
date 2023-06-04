using EleicaoDigital.Application.Models.InputModel;
using EleicaoDigital.Application.Models.ViewModel;
using EleicaoDigital.Repository.Entities;

namespace EleicaoDigital.Application.Services.Usuario
{
    public interface IUsuarioService
    {
        UsuarioLoginViewModel? Login(string email, string password);
        UsuarioNovoViewModel CadastrarUsuario(UsuarioRequest usuarioRequest);
        UsuarioViewModel ObterUsuarioPorEmail(string email);
        string GerarTokenJwt(UsuarioViewModel usuario);
    }
}
