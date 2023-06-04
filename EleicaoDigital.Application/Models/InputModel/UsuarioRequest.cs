

namespace EleicaoDigital.Application.Models.InputModel
{
    public class UsuarioRequest
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Usuario { get; set; }
        public string? Senha { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }
        public string? Instagram { get; set; }
        public string? Telefone { get; set; }
        public string? Bairro { get; set; }
        public int Quantidade { get; set; }
        public string? Lider { get; set; }
    }
}
