using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_PAISES")]
public partial class CrmPaise
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("DESCRICAO")]
    [StringLength(50)]
    public string? Descricao { get; set; }

    [Column("CODIGO")]
    [StringLength(5)]
    public string? Codigo { get; set; }

    [Column("COUNTRID")]
    [StringLength(50)]
    public string? Countrid { get; set; }

    [Column("MARKETTYPE")]
    public int? Markettype { get; set; }

    [Column("SAFTCODE")]
    [StringLength(50)]
    public string? Saftcode { get; set; }
}
