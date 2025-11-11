using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Construlink.Models
{
    [Table("EstadoManutencao")]
    public class EstadoManutencao
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public bool Estado { get; set; } = false;
    }
}
