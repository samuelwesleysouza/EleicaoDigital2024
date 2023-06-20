using EleicaoDigital.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

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
        public tabUsuario ObterUsuarioPorEmail(string email)
        {
            return _context.tabUsuario.FirstOrDefault(b => b.Email == email);
        }

        public List<tabUsuario> ObterTodos()
        {
            return _context.tabUsuario.AsNoTracking().ToList();
        }
        public List<tabUsuario> ObterPorBairroOuLider(string bairro, int? lider)
        {
            return _context.tabUsuario.AsNoTracking().Where(u => u.Bairro == bairro || u.UsuarioCadastroCodigo == lider).ToList();
        }
    }
}
