using System.ComponentModel.DataAnnotations;

namespace EleicaoDigital.Repository.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public int? UsuarioCadastroCodigo { get; set; }
        public DateTime? DataUltimaAlteracao { get; set; }
        public int? UsuarioAlteracaoCodigo { get; set; }
    }
}
