using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("OSUSR_N2P_FRACOES")]
public partial class OsusrN2pFraco
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("DESCRICAO")]
    [StringLength(100)]
    public string? Descricao { get; set; }

    [Column("BLOCO")]
    [StringLength(50)]
    public string? Bloco { get; set; }

    [Column("AREABRUTA")]
    [StringLength(50)]
    public string? Areabruta { get; set; }

    [Column("NOTAS")]
    [StringLength(4000)]
    public string? Notas { get; set; }

    [Column("CodigoObraPai")]
    [StringLength(50)]
    public string? CodigoObraPai { get; set; }

    [Column("IMAGEM")]
    [StringLength(4000)]
    public string? Imagem { get; set; }

    [Column("AREAUTIL")]
    [StringLength(50)]
    public string? Areautil { get; set; }

    [Column("TIPOLOGIA")]
    [StringLength(50)]
    public string? Tipologia { get; set; }

    [Column("ANDAR")]
    [StringLength(50)]
    public string? Andar { get; set; }

    [Column("GARAGEM")]
    [StringLength(50)]
    public string? Garagem { get; set; }

    [Column("VALOR_TOTAL", TypeName = "decimal(37, 2)")]
    public decimal? ValorTotal { get; set; }

    [Column("ESTADO")]
    public int? Estado { get; set; }

    [Column("IMOBILIARIA")]
    [StringLength(12)]
    public string? Imobiliaria { get; set; }

    [Column("CLIENTE")]
    [StringLength(12)]
    public string? Cliente { get; set; }

    [Column("DATA_ENTREGA", TypeName = "datetime")]
    public DateTime? DataEntrega { get; set; }

    [Column("DATA_CPCV", TypeName = "datetime")]
    public DateTime? DataCpcv { get; set; }

    [Column("IsDeleted")]
    public bool? IsDeleted { get; set; }
}
