using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_MOTIVOSISENCAO")]
public partial class CrmMotivosisencao
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("DESCRICAO")]
    [StringLength(250)]
    public string? Descricao { get; set; }

    [Column("ERPID")]
    [StringLength(50)]
    public string? Erpid { get; set; }

    [Column("CODIGOERP")]
    [StringLength(50)]
    public string? Codigoerp { get; set; }
}
