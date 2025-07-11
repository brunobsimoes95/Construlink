using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Construlink.Models
{
    [Table("PatchNotes")]
    public class PatchNotes
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("Data", TypeName = "datetime")]
        public DateTime? Data { get; set; }

        [Column("Mensagem")]
        [StringLength(350)]
        public string? Mensagem { get; set; }
        public bool? IsTitulo { get; set; } = false;
        public bool? IsAtivo { get; set; } = true;
        public bool? IsDeleted { get; set; } = false;

    }
}
