using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("OSUSR_N2P_MODOSPAGAMENTO")]
public partial class OsusrN2pModospagamento
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("MOVIM")]
    [StringLength(5)]
    public string? Movim { get; set; }

    [Column("DESCRICAO")]
    [StringLength(50)]
    public string? Descricao { get; set; }

    [Column("TIPOMV")]
    [StringLength(1)]
    public string? Tipomv { get; set; }

    [Column("EMPRESAID")]
    public int? Empresaid { get; set; }
}
