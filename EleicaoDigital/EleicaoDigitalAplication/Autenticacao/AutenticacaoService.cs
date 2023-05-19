using EleicaoDigitalAplication.Models.ModelRequest;
using EleicaoDigitalAplication.Models.ModelResponse;
using EleicaoRepository;
using EleicaoRepository.ModelsTabelaSql;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace EleicaoDigitalAplication.Autenticacao
{
    public class AutenticacaoServices
    {
        private readonly EleicaoContext _context;
        public AutenticacaoServices(EleicaoContext context)
        {
            _context = context;
        }
        public AutenticacaoResponse Autenticar(AutenticacaoRequest request)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.usuario == request.UserName && x.senha == request.Password && x.email == request.Email);
            if (usuario != null)
            {
                var tokenString = GerarTokenJwt(usuario);
                var resposta = new AutenticacaoResponse()  //Criamos um novo Objeto de resposta para pegar o token + id como resposta para alterar senha de usuario
                {
                    token = tokenString,
                    UsuarioId = usuario.id
                };
                return resposta;
            }
            else
            {
                return null;
            }
        }

        private string GerarTokenJwt(TabUsuario usuario) //Passo 1 Gerar o token  Criar um método para ser utilizado acima nas validações ele inicia aqui para gerar transformar em string no token e depois retorna na string acima 
        {
            var issuer = "";  // Quem vai utilizar o nome  Passo02 
            var audience = ""; // Password do token para quem vai utilizar Passo03
            var key = "b23ced2d-db9e-43e8-b297-0656d6393282"; //Uma guide aleatoria de token no google Passo04

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)); //Uma securitykey juntamente com uma base simétrica UTF8 gerando a key com getby para ele auto gerar nesse modelo  Passo05
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); //Passo06

            var claims = new[] //Claims salvar registro 
            {
                new Claim("usuarioId", usuario.id.ToString()),
                new Claim(ClaimTypes.Role, usuario.role.ToString())
            };

            var token = new JwtSecurityToken(issuer: issuer, claims: claims, audience: audience, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

    }
}
