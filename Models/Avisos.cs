using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DocumentFormat.OpenXml.Drawing;

namespace Construlink.Models
{
    [Table("Avisos")]
    public class Avisos
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Tipo")]
        [StringLength(100)]
        public string? Tipo { get; set; }

        [Column("Mensagem")]
        [StringLength(350)]
        public string? Mensagem { get; set; }
        public TimeSpan? HoraInicio { get; set; } = default;
        public TimeSpan? HoraFim { get; set; } = default;
        public int? IdEmpresa { get; set; } = 0;

        [Column("DataFim", TypeName = "datetime")]
        public DateTime? DataFim { get; set; }

        public bool IsAtivo { get; set; } = true;

        public bool IsDeleted { get; set; } = false;
    }
}
