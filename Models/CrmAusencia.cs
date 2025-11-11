using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Construlink.Models
{
    public partial class CrmAusencia
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("IdColaborador")]
        public int IdColaborador { get; set; }

        [StringLength(100)]
        public string? NomeColaborador { get; set; }

        [Required]
        [StringLength(20)]
        public string TipoAusencia { get; set; } // Temporária, Falta, Férias, Folga

        [StringLength(500)]
        public string? Descricao { get; set; }

        [Column("DataInicio", TypeName = "datetime")]
        public DateTime DataInicio { get; set; }

        [Column("DataFim", TypeName = "datetime")]
        public DateTime? DataFim { get; set; }

        [Column("HoraInicio")]
        public TimeSpan? HoraInicio { get; set; }

        [Column("HoraFim")]
        public TimeSpan? HoraFim { get; set; }

        [Column("CriadaPor")]
        public int? CriadaPor { get; set; }

        [Column("DataCriacao", TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }

        [Column("EditadaPor")]
        public int? EditadaPor { get; set; }

        [Column("DataEdicao", TypeName = "datetime")]
        public DateTime? DataEdicao { get; set; }

        [Column("IsDeleted")]
        public bool? IsDeleted { get; set; } = false;

        [Column("Observacoes")]
        [StringLength(1000)]
        public string? Observacoes { get; set; }

        // Propriedades de navegação
        [ForeignKey("IdColaborador")]
        public virtual Funcionario? Colaborador { get; set; }
    }
}