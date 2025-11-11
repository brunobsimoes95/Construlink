using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Construlink.Models
{
    public class Epis
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int IdEticadata { get; set; }

        [StringLength(150)]
        public string? Descricao { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
