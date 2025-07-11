using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_AUDITORIA")]
public partial class CrmAuditorium
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("UTILIZADORID")]
    public int? Utilizadorid { get; set; }

    [Column("DATA", TypeName = "datetime")]
    public DateTime? Data { get; set; }

    [Column("COMPORTAMENTO")]
    public string? Comportamento { get; set; }
}
