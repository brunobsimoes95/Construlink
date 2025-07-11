using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_EMPRESAS")]
public partial class CrmEmpresa
{
    [Key]
    public int Id { get; set; }

    public int? NumeroPicagens { get; set; } = 4;

    [StringLength(80)]
    public string Empresa { get; set; } = null!;

    [StringLength(50)]
    public string? Favicon { get; set; }

    [StringLength(50)]
    public string? LogoNavBar { get; set; }

    [StringLength(10)]
    public string? Cor1 { get; set; }

    [StringLength(10)]
    public string? Cor2 { get; set; }

    [StringLength(10)]
    public string? Cor3 { get; set; }

    [StringLength(50)]
    public string? ImagemCard { get; set; }

    [StringLength(50)]
    public string? ImagemIndex { get; set; }

    [StringLength(150)]
    public string? Descricao { get; set; }

    [StringLength(50)]
    public string? BaseNome { get; set; }
}
