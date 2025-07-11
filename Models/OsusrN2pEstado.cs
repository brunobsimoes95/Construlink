using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("OSUSR_N2P_ESTADOS")]
public partial class OsusrN2pEstado
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("CODIGO")]
    [StringLength(5)]
    public string? Codigo { get; set; }

    [Column("DESCRICAO")]
    [StringLength(50)]
    public string? Descricao { get; set; }

    [Column("ORDEM")]
    public int? Ordem { get; set; }

    [Column("EMPRESAID")]
    public int? Empresaid { get; set; }
}
