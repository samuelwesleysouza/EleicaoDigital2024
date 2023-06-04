using System.ComponentModel.DataAnnotations;

namespace EleicaoDigital.Repository.Entities
{
    public class tabUsuario
    {
        [Key]
        public int Id { get; set; }
        public int PessoaCodigo{ get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Role { get; set; }
        public DateTime DataCadastroUsuario { get; set; }
        ///public virtual tabPessoa? Pessoa { get; set; }
        //public virtual ICollection<tabPostUsuario>? PostsUsuarios { get; set; }

    }
}
