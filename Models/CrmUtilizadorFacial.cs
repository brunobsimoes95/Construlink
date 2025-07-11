using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_UTILIZADOR_FACIAL")]
public partial class CrmUtilizadorFacial
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ID_UTILIZADOR")]
    public int IdUtilizador { get; set; }

    [Column("NAME")]
    [StringLength(100)]
    public string? Name { get; set; }

    [Column("BIOMARKERS")]
    public string? Biomarkers { get; set; }
}
