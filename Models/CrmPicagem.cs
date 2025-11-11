using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_PICAGEM")]
public partial class CrmPicagem
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("UTILIZADORID")]
    public int? Utilizadorid { get; set; }

    [Column("ENTRADA", TypeName = "datetime")]
    public DateTime? Entrada { get; set; }

    [Column("INICIO_ALMOCO", TypeName = "datetime")]
    public DateTime? InicioAlmoco { get; set; }

    [Column("FIM_ALMOCO", TypeName = "datetime")]
    public DateTime? FimAlmoco { get; set; }

    [Column("SAIDA", TypeName = "datetime")]
    public DateTime? Saida { get; set; }

    [Column("IP1")]
    [StringLength(50)]
    public string? Ip1 { get; set; }

    [Column("IP2")]
    [StringLength(50)]
    public string? Ip2 { get; set; }

    [Column("IP3")]
    [StringLength(50)]
    public string? Ip3 { get; set; }

    [Column("IP4")]
    [StringLength(50)]
    public string? Ip4 { get; set; }

    [Column("SAIDA_FORCADA")]
    public bool? SaidaForcada { get; set; }

    [Column("DATA", TypeName = "datetime")]
    public DateTime? Data { get; set; }

    [Column("LATITUDE")]
    public double? Latitude { get; set; }

    [Column("LONGITUDE")]
    public double? Longitude { get; set; }

    [Column("AREA")]
    [StringLength(150)]
    public string? Area { get; set; }

    public bool? IsFalta { get; set; } = false;
    public bool? IsFerias { get; set; } = false;
    public bool? IsFolga { get; set; } = false;
    public bool? IsFaltaJustificada { get; set; } = false;
    public double? HorasFaltaParcial { get; set; }

}
