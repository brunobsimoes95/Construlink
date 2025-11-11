using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_CONFIG")]
public partial class CrmConfig
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OPTION")]
    [StringLength(25)]
    public string? Option { get; set; }

    [Column("VALUE")]
    [StringLength(50)]
    public string? Value { get; set; }
}
