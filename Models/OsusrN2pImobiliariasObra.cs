using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("OSUSR_N2P_IMOBILIARIAS_OBRA")]
public partial class OsusrN2pImobiliariasObra
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OBRA_ID")]
    public int? ObraId { get; set; }

    [Column("ENTIDADE")]
    [StringLength(12)]
    public string? Entidade { get; set; }
}
