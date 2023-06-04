using EleicaoDigital.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EleicaoDigital.Repository.Repository.PostUsuario
{
    public class PostsUsuarioRepository : IPostsUsuarioRepository
    {
        public Context _context { get; }
        public PostsUsuarioRepository(Context context)
        {
            _context = context;
        }

        public bool AtualizarPost(tabPostUsuario updatedPost)
        {
            try
            {
                _context.tabPostsUsuario.Update(updatedPost);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public tabPostUsuario InserirNovoPost(tabPostUsuario newPost)
        {
            _context.tabPostsUsuario.Add(newPost);
            _context.SaveChanges();

            return newPost;
        }

        public List<tabPostUsuario> ObterPost()
        {
            return _context.tabPostsUsuario.AsQueryable().ToList();
        }

        public bool RemoverPost(int id)
        {
            try
            {
                var post = _context.tabPostsUsuario.FirstOrDefault(p => p.Id == id);

                if (post != null)
                {
                    _context.tabPostsUsuario.Remove(post);
                    _context.SaveChanges();
                    return true;
                }
                else
                    return false;
               
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
