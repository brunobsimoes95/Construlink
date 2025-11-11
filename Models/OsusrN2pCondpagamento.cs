using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("OSUSR_N2P_CONDPAGAMENTO")]
public partial class OsusrN2pCondpagamento
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("CONDPAG")]
    [StringLength(5)]
    public string? Condpag { get; set; }

    [Column("DESCRICAO")]
    [StringLength(50)]
    public string? Descricao { get; set; }

    [Column("DIAS")]
    public int? Dias { get; set; }

    [Column("EMPRESAID")]
    public int? Empresaid { get; set; }
}
