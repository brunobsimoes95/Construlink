using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_SERIE_DOCUMENTO")]
public partial class CrmSerieDocumento
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("TIPODOCUMENTOID")]
    public int? Tipodocumentoid { get; set; }

    [Column("SERIE")]
    [StringLength(50)]
    public string? Serie { get; set; }

    [Column("ULTIMODOCUMENTO")]
    public int? Ultimodocumento { get; set; }

    [Column("SETORERP")]
    [StringLength(50)]
    public string? Setorerp { get; set; }

    [Column("ERPID")]
    [StringLength(50)]
    public string? Erpid { get; set; }

    [Column("LAYOUTID")]
    [StringLength(50)]
    public string? Layoutid { get; set; }

    [Column("LOJAID")]
    public int? Lojaid { get; set; }

    [Column("ISDEFAULT")]
    public bool? Isdefault { get; set; }
}
