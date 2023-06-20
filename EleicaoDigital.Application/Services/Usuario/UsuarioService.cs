using EleicaoDigital.Application.Models.Enums;
using EleicaoDigital.Application.Models.InputModel;
using EleicaoDigital.Application.Models.ViewModel;
using EleicaoDigital.Repository.Entities;
using EleicaoDigital.Repository.Repository.Usuario;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
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

        public UsuarioLoginViewModel Login(string email, string password)
        {
            var usuario = _usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario is null)
                return new UsuarioLoginViewModel
                {
                    Usuario = null,
                    Token = string.Empty,
                    Message = "Login ou Senha incorretos"
                };

            if (usuario.Email.Equals(email) && usuario.Senha.Equals(password))
            {
                var usuariViewModel = new UsuarioViewModel
                {
                    Id = usuario.Codigo,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Telefone = usuario.Telefone,
                    Instagram = usuario.Instagram,
                    Logradouro = usuario.Logradouro,
                    Bairro = usuario.Bairro
                };

                return new UsuarioLoginViewModel
                {
                    Usuario = usuariViewModel,
                    Token = GerarTokenJwt(usuariViewModel, usuario.Role),
                    Message = string.Empty
                };
            }
            else
            {
                return new UsuarioLoginViewModel
                {
                    Usuario = null,
                    Token = string.Empty,
                    Message = "Login ou Senha incorretos"
                };
            }
        }

        public UsuarioLoginViewModel CadastrarUsuario(UsuarioRequest usuarioRequest, int usuarioLiderCadastro)
        {
            var usuario = _usuarioRepository.ObterUsuarioPorEmail(usuarioRequest.Email);

            if (usuario is null)
                usuario = _usuarioRepository.CadastrarUsuario(new tabUsuario
                {
                    Email = usuarioRequest.Email,
                    Nome = usuarioRequest.Nome,
                    Senha = usuarioRequest.Senha,
                    Role = usuarioRequest.Role,
                    Logradouro = usuarioRequest.Logradouro,
                    Bairro = usuarioRequest.Bairro,
                    Instagram = usuarioRequest.Instagram,
                    Telefone = usuarioRequest.Telefone,
                    DataCadastro = DateTime.Now,
                    UsuarioCadastroCodigo = usuarioLiderCadastro,
                });

            var usuariViewModel = new UsuarioViewModel
            {
                Id = usuario.Codigo,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Telefone = usuario.Telefone,
                Instagram = usuario.Instagram,
                Logradouro = usuario.Logradouro,
                Bairro = usuario.Bairro
            };

            return new UsuarioLoginViewModel
            {
                Usuario = usuariViewModel,
                Token = GerarTokenJwt(usuariViewModel, usuario.Role),
                Message = string.Empty
            };
        }

        public UsuarioViewModel ObterUsuarioPorEmail(string email)
        {
            var usuarioModel = _usuarioRepository.ObterUsuarioPorEmail(email);

            var usuarioViewModel = new UsuarioViewModel
            {
                Id = usuarioModel.Codigo,
                Nome = usuarioModel.Nome,
                Email = usuarioModel.Email,
                Telefone = usuarioModel.Telefone,
                Instagram = usuarioModel.Instagram,
                Logradouro = usuarioModel.Logradouro,
                Bairro = usuarioModel.Bairro
            };

            return usuarioViewModel;
        }

        public List<UsuarioViewModel> ObterTodos()
        {
            var usuarios = _usuarioRepository.ObterTodos();
            if (usuarios.Any())
                return usuarios.Select(u => new UsuarioViewModel
                {
                    Id = u.Codigo,
                    Nome = u.Nome,
                    Email = u.Email,
                    Telefone = u.Telefone,
                    Instagram = u.Instagram,
                    Logradouro = u.Logradouro,
                    Bairro = u.Bairro
                }).ToList();
            else
                return new List<UsuarioViewModel>();
        }

        public List<UsuarioViewModel> ObterPorBairroOuLider(string bairro, int? lider)
        {
            var usuarios = _usuarioRepository.ObterPorBairroOuLider(bairro, lider);

            if (usuarios.Any())
                return usuarios.Select(u => new UsuarioViewModel
                {
                    Id = u.Codigo,
                    Nome = u.Nome,
                    Email = u.Email,
                    Telefone = u.Telefone,
                    Instagram = u.Instagram,
                    Logradouro = u.Logradouro,
                    Bairro = u.Bairro
                }).ToList();
            else
                return new List<UsuarioViewModel>();
        }

        public string GerarTokenJwt(UsuarioViewModel usuario, string role)
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
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Role, role.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
