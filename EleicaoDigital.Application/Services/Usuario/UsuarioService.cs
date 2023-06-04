using EleicaoDigital.Application.Models.InputModel;
using EleicaoDigital.Application.Models.ViewModel;
using EleicaoDigital.Application.Services.Pessoa;
using EleicaoDigital.Repository.Entities;
using EleicaoDigital.Repository.Repository.Usuario;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace EleicaoDigital.Application.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public UsuarioLoginViewModel? Login(string email, string password)
        {
            var usuario = _usuarioRepository.ObterUsarioPorEmail(email);

            if (usuario is null)
                return new UsuarioLoginViewModel
                {
                    usuarioId = 0,
                    Token = string.Empty,
                    Message = "Login ou Senha incorretos"
                }; 

            if (usuario.Email.Equals(email) && usuario.Senha.Equals(password))
            {
                var usuariViewModel = new UsuarioViewModel
                {
                    Id = usuario.Id,
                    Role = usuario.Role,
                    Username = usuario.UserName,
                };

                return new UsuarioLoginViewModel
                {
                    usuarioId = usuariViewModel.Id,
                    Token = GerarTokenJwt(usuariViewModel),
                    Message = string.Empty
                };
            }
            else
            {
                return new UsuarioLoginViewModel
                {
                    usuarioId = 0,
                    Token = string.Empty,
                    Message = "Login ou Senha incorretos"
                };
            }
        }

        public UsuarioNovoViewModel CadastrarUsuario(UsuarioRequest usuarioRequest)
        {
            var usarioConsulta = _usuarioRepository.ObterUsarioPorEmail(usuarioRequest.Email);

            if (usarioConsulta is null)
                _usuarioRepository.CadastrarUsuario(new tabUsuario
                {

                });

            var usarioViewModel = new UsuarioNovoViewModel { };

            return usarioViewModel;
        }

        public UsuarioViewModel ObterUsuarioPorEmail(string email)
        {
            var usarioModel = _usuarioRepository.ObterUsarioPorEmail(email);

            var usarioViewModel = new UsuarioViewModel
            {

            };

            return usarioViewModel;
        }

        public string GerarTokenJwt(UsuarioViewModel usuario)
        {
            var issuer = "var"; 
            var audience = "var";
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes("b23ced2d-db9e-43e8-b297-0656d6393282");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Username),
                    new Claim(ClaimTypes.Role, usuario.Role.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
