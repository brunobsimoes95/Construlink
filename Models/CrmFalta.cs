using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_FALTAS")]
public partial class CrmFalta
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Falta { get; set; }

    [StringLength(50)]
    public string? Descricao { get; set; }
}
