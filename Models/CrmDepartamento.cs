using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_DEPARTAMENTOS")]
public partial class CrmDepartamento
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Empresa { get; set; }

    [StringLength(50)]
    public string? Departamento { get; set; }

    [StringLength(50)]
    public string? Descricao { get; set; }
}
