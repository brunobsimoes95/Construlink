using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Construlink.Models
{
    [Table("CRM_LINGUA")]
    public class CrmLingua
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        [StringLength(200)]
        public string? Descricao { get; set; }
        
        [Column("Codigo")]
        [StringLength(200)]
        public string? Codigo { get; set; }
    }
}
