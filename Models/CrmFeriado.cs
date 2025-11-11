using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_FERIADOS")]
public partial class CrmFeriado
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("DESCRICAO")]
    [StringLength(50)]
    public string? Descricao { get; set; }

    [Column("MES")]
    public int? Mes { get; set; }

    [Column("DIA")]
    public int? Dia { get; set; }

    [Column("TRABALHA")]
    public bool? Trabalha { get; set; }

    [Column("edita")]
    public bool? Edita { get; set; }
}
