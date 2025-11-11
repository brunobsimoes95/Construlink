using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_CONCELHO")]
public partial class CrmConcelho
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("DISTRITOID")]
    public int? Distritoid { get; set; }

    [Column("DESCRICAO")]
    [StringLength(50)]
    public string? Descricao { get; set; }

    [Column("CUSTO", TypeName = "decimal(37, 8)")]
    public decimal? Custo { get; set; }

    [Column("CUSTO2", TypeName = "decimal(37, 8)")]
    public decimal? Custo2 { get; set; }
}
