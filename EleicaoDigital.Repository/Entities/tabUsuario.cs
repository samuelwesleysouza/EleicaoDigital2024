using EleicaoDigital.Repository.Entities.Base;

namespace EleicaoDigital.Repository.Entities
{
    public class tabUsuario : BaseEntity
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Role { get; set; }
        public string? Instagram { get; set; }
        public string? Telefone { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
    }
}
