using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_TIPO_DOCUMENTO")]
public partial class CrmTipoDocumento
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("NOME")]
    [StringLength(50)]
    public string? Nome { get; set; }

    [Column("ENTRADASAIDA")]
    [StringLength(1)]
    public string? Entradasaida { get; set; }

    [Column("MODULO")]
    [StringLength(1)]
    public string? Modulo { get; set; }

    [Column("MOVSTOCKS")]
    public bool? Movstocks { get; set; }

    [Column("DEBITOCREDITO")]
    [StringLength(1)]
    public string? Debitocredito { get; set; }

    [Column("CODIGOERP")]
    [StringLength(15)]
    public string? Codigoerp { get; set; }

    [Column("ERPID")]
    [StringLength(50)]
    public string? Erpid { get; set; }

    [Column("CLASS")]
    [StringLength(5)]
    public string? Class { get; set; }

    [Column("ATIVO")]
    public bool? Ativo { get; set; }

    [Column("CONTACORRENTE")]
    public bool? Contacorrente { get; set; }

    [Column("PRECOSCOMIVA")]
    public bool? Precoscomiva { get; set; }

    [Column("CONTABILISTICO")]
    public bool? Contabilistico { get; set; }

    [Column("CUSTOOBRA")]
    public bool? Custoobra { get; set; }

    [Column("INTEGRA_WT")]
    public bool? IntegraWt { get; set; }

    [Column("RESERVASTOCK")]
    public bool? Reservastock { get; set; }

    [Column("ISDOCTRANSPORTE")]
    public bool? Isdoctransporte { get; set; }

    [Column("IS_ORDEM_FABRICO")]
    public bool? IsOrdemFabrico { get; set; }

    [Column("IS_DOC_ARMAZEM")]
    public bool? IsDocArmazem { get; set; }

    [Column("REPORT")]
    [StringLength(50)]
    public string? Report { get; set; }

    [Column("SELECTION_FORMULA")]
    [StringLength(250)]
    public string? SelectionFormula { get; set; }

    [Column("ISREGULARIZACAO")]
    public bool? Isregularizacao { get; set; }

    [Column("IS_ACERTO_STOCK")]
    public bool? IsAcertoStock { get; set; }

    [Column("EDITAVEL")]
    public bool? Editavel { get; set; }
}
