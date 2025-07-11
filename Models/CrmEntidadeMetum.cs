using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_ENTIDADE_META")]
public partial class CrmEntidadeMetum
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("entidade_id")]
    public int? EntidadeId { get; set; }

    [Column("meta_key")]
    [StringLength(100)]
    public string? MetaKey { get; set; }

    [Column("meta_value")]
    public string? MetaValue { get; set; }
}
