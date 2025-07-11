using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

public partial class Contrato
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("IdFuncionario")]
    public int? IdFuncionario { get; set; }

    [Column("NumMecanografico")]
    public int? NumMecanografico { get; set; }

    [StringLength(250)]
    public string? Nome { get; set; }

    [StringLength(250)]
    public string? Cargo { get; set; }

    [StringLength(100)]
    public string? TipoContrato { get; set; }

    [StringLength(100)]
    public string? Empresa { get; set; }

    [Column("PrimeiraHoraExtra", TypeName = "decimal(18, 2)")]
    public decimal? PrimeiraHoraExtra { get; set; }

    [Column("HoraExtraSub", TypeName = "decimal(18, 2)")]
    public decimal? HoraExtraSubsequent { get; set; }

    [Column("OrdenadoHora", TypeName = "decimal(18, 2)")]
    public decimal? OrdenadoHora { get; set; }

    [Column("OrdenadoBase", TypeName = "decimal(18, 2)")]
    public decimal? OrdenadoBase { get; set; }

    [Column("DataInicio", TypeName = "datetime")]
    public DateTime? DataInicio { get; set; }

    [Column("DataAlteracao", TypeName = "datetime")]
    public DateTime? DataAlteracao { get; set; }

    public int? DiaVencimento { get; set; }

    [Column("PeriodoExperiencia")]
    public bool? PeriodoExperiencia { get; set; }

    [Column("ContratoAtivo")]
    public bool? ContratoAtivo { get; set; }

    [Column("Pica4")]
    public bool? Pica4 { get; set; }
}