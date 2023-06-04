using EleicaoDigital.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleicaoDigital.Repository.Repository.PostUsuario
{
    public interface IPostsUsuarioRepository
    { 
        tabPostUsuario InserirNovoPost(tabPostUsuario newPost);
        List<tabPostUsuario> ObterPost();
        bool AtualizarPost(tabPostUsuario updatedPost);
        bool RemoverPost(int id);
    }
}
