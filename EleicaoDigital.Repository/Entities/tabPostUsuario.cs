using System.ComponentModel.DataAnnotations;

namespace EleicaoDigital.Repository.Entities
{
    public class tabPostUsuario
    {
        [Key]
        public int Id { get; set; }
        public string? TituloPost { get; set; }
        public string? Texto { get; set; }
        public DateTime DataPost { get; set; }
        public int UsuarioCriacaoId { get; set; }
        public string? CaminhoArquivoPost { get; set; }
       // public virtual tabUsuario? Usuario { get; set; }
    }
}
