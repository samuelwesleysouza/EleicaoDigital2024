using EleicaoDigital.Repository.Entities;

namespace EleicaoDigital.Repository.Repository.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Context _context { get; }

        public UsuarioRepository(Context context)
        {
            _context = context;
        }

        public tabUsuario CadastrarUsuario(tabUsuario usuarioModel)
        {
            _context.tabUsuario.Add(usuarioModel);
            _context.SaveChanges();

            return usuarioModel;

        }
        public tabUsuario ObterUsarioPorEmail(string email)
        {
            return _context.tabUsuario.FirstOrDefault(b => b.Email == email);
        }
    }
}
