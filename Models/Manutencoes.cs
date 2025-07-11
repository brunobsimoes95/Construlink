using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.Channels;

namespace Construlink.Models
{
    [Table("Manutencoes")]
    public class Manutencoes
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Titulo")]
        [StringLength(100)]
        public string? Titulo { get; set; }

        [Column("Mensagem")]
        [StringLength(350)]
        public string? Mensagem { get; set; }
        public TimeSpan? HoraRetorno { get; set; } = default;
        public bool IsAtivo { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
    }
}
