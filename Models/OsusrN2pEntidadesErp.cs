using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("OSUSR_N2P_ENTIDADES_ERP")]
public partial class OsusrN2pEntidadesErp
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("TIPOENTIDADE")]
    [StringLength(1)]
    public string? Tipoentidade { get; set; }

    [Column("ENTIDADE")]
    [StringLength(12)]
    public string? Entidade { get; set; }

    [Column("NOME")]
    [StringLength(100)]
    public string? Nome { get; set; }

    [Column("NOMEFISCAL")]
    [StringLength(150)]
    public string? Nomefiscal { get; set; }

    [Column("MORADA")]
    [StringLength(100)]
    public string? Morada { get; set; }

    [Column("MORADA2")]
    [StringLength(100)]
    public string? Morada2 { get; set; }

    [Column("LOCALIDADE")]
    [StringLength(100)]
    public string? Localidade { get; set; }

    [Column("CP")]
    [StringLength(20)]
    public string? Cp { get; set; }

    [Column("CP_LOC")]
    [StringLength(50)]
    public string? CpLoc { get; set; }

    [Column("TEL")]
    [StringLength(50)]
    public string? Tel { get; set; }

    [Column("NUMCONTRIB")]
    [StringLength(50)]
    public string? Numcontrib { get; set; }

    [Column("PAIS")]
    [StringLength(5)]
    public string? Pais { get; set; }

    [Column("TIPOMERCADO")]
    [StringLength(5)]
    public string? Tipomercado { get; set; }

    [Column("MOEDA")]
    [StringLength(50)]
    public string? Moeda { get; set; }

    [Column("EMPRESAID")]
    public int? Empresaid { get; set; }
}
