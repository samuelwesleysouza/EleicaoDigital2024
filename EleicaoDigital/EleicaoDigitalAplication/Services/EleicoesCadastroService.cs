using EleicaoDigitalAplication.Models.ModelRequest;
using EleicaoDigitalAplication.Models.ModelResponse;
using EleicaoRepository;
using EleicaoRepository.ModelsTabelaSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleicaoDigitalAplication.Services
{
    public class EleicoesCadastroService
    {

        private readonly EleicaoContext _context;

        public EleicoesCadastroService(EleicaoContext context)
        {
            _context = context;
        }

        public CadastroResponse SalvarDadosCadastrais(CadastroRequest request)
        {
            var conferirCadastro = _context.Usuarios.FirstOrDefault(x => x.email == request.email);
            if (conferirCadastro != null)
            {
                return new CadastroResponse()
                {
                    mensagem = "Usuário com o mesmo e-mail já existe."
                };
            }

            var pessoa = new TabUsuario()
            {
                nome = request.nome,
                usuario = request.usuario,
                senha = request.senha,
                role = request.role,
                email = request.email,
                instagram = request.instagram,
                telefone = request.telefone,
                bairro = request.bairro,
                quantidade = request.quantidade,
                lider = request.lider,
                datacadastro = DateTime.Now
            };

            _context.Usuarios.Add(pessoa);
            _context.SaveChanges();

            return new CadastroResponse()
            {
                nome = pessoa.nome,
                usuario = pessoa.usuario,
                mensagem = "Usuário cadastrado com sucesso.",
            };
        }

        public TabUsuario ObterUsuario(string email)  //CRUD - READ     LEITURA
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(x => x.email == email); //va na tabela usuario e procura esses id
                return usuario;
            }
            catch (Exception ex)
            {
                return null;   //o null eu tratei na Service sobre bad Request
            }
        }
    }
}

