using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_ARTIGO_FORNECEDOR")]
public partial class CrmArtigoFornecedor
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ARTIGOID")]
    public int? Artigoid { get; set; }

    [Column("FORNECEDOR")]
    public int? Fornecedor { get; set; }

    [Column("ISCLIENTE")]
    public bool? Iscliente { get; set; }

    [Column("ARTIGOCODEXT")]
    [StringLength(50)]
    public string? Artigocodext { get; set; }

    [Column("ARTIGODESC")]
    [StringLength(50)]
    public string? Artigodesc { get; set; }
}
