using System.ComponentModel.DataAnnotations;

namespace EleicaoDigital.Repository.Entities
{
    public class tabPessoa
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Instagram { get; set; }
        public string? Telefone { get; set; }
        public string? Bairro { get; set; }
        public int UsuarioResponsavelCodigo { get; set; }
        public DateTime DataCadastro { get; set; }
        //public virtual tabUsuario? UsuarioResponsavel { get; set; }
        //public virtual tabUsuario? Usuario { get; set; }
    }
}
