using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Construlink.Models
{
    public class TipoTurno
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [StringLength(100)]
        public string? Nome { get; set; }
    }
}
