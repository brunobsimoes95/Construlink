using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("OSUSR_N2P_PROCESSO")]
public partial class OsusrN2pProcesso
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PARENTID")]
    public int? Parentid { get; set; }

    [Column("CODIGO")]
    [StringLength(10)]
    public string? Codigo { get; set; }

    [Column("DESCRICAO")]
    [StringLength(100)]
    public string? Descricao { get; set; }

    [Column("RESPONSAVEL")]
    public int? Responsavel { get; set; }

    [Column("ATIVO")]
    public bool? Ativo { get; set; }
}
