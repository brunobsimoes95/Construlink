using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Construlink.Models
{
    [Table("CRM_ANEXOS")]
    public partial class CrmAnexo
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("categoria")]
        [StringLength(45)]
        public string? Categoria { get; set; }

        [Column("categoria_id")]
        public int CategoriaId { get; set; }

        [Column("file_path")]
        [StringLength(255)]
        public string FilePath { get; set; } = null!;
    }
}