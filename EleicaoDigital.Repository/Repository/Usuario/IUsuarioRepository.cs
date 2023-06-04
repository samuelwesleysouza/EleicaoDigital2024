using EleicaoDigital.Repository.Entities;

namespace EleicaoDigital.Repository.Repository.Usuario
{
    public interface IUsuarioRepository
    {
        tabUsuario CadastrarUsuario(tabUsuario usuarioModel);
        tabUsuario ObterUsarioPorEmail(string email);
    }
}
