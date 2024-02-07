using EleicaoDigital.Repository.Entities;

namespace EleicaoDigital.Repository.Repository.Usuario
{
    public interface IUsuarioRepository
    {
        tabUsuario CadastrarUsuario(tabUsuario usuarioModel);
        tabUsuario ObterUsuarioPorEmail(string email);
        List<tabUsuario> ObterTodos();
        List<tabUsuario> ObterPorBairroOuLider(string bairro, int? lider);
        List<tabUsuario> ObterQuatidadedeCadastoLider(string bairro, int? lider);
    }
}
