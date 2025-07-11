using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Construlink.Models
{
    [Table("Turnos")]
    public class Turnos
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        public int? Tipo { get; set; }

        [Column("NomeTipo")]
        [StringLength(100)]
        public string? NomeTipo { get; set; }
        public TimeSpan? Entrada { get; set; } = default;
        public TimeSpan? Pausa { get; set; } = default;
        public TimeSpan? Retorno { get; set; } = default;
        public TimeSpan? Saida { get; set; } = default;
    }
}
