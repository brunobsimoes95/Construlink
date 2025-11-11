using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_PRAZO_PAGAMENTO")]
public partial class CrmPrazoPagamento
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("DESCRICAO")]
    [StringLength(50)]
    public string? Descricao { get; set; }

    [Column("ERPID")]
    [StringLength(50)]
    public string? Erpid { get; set; }

    [Column("CODIGO")]
    [StringLength(50)]
    public string? Codigo { get; set; }

    [Column("NUMDIAS")]
    public int? Numdias { get; set; }
}
