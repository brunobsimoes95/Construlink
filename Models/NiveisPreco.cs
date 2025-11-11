using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Construlink.Models
{
    [Table("NiveisPreco")]
    public class NiveisPreco
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string? Descricao { get; set; }

        public bool? IsDeleted { get; set; }

        public decimal? Adicional { get; set; }
    }
}
