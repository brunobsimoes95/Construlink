using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Construlink.Models
{
    public class ColaboradorEPI
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int? IdEpi { get; set; }
        public int? IdColaborador { get; set; }

        [StringLength(150)]
        public string? NomeEpi { get; set; }
        public DateTime? DataAtribuicao { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
