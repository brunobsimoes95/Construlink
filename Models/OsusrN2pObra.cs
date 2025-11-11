using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("OSUSR_N2P_OBRA")]
public partial class OsusrN2pObra
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("CODIGO")]
    [StringLength(50)]
    public string? Codigo { get; set; }

    [Column("NOME")]
    [StringLength(250)]
    public string? Nome { get; set; }

    [Column("CLIENTE")]
    [StringLength(50)]
    public string? Cliente { get; set; }

    [Column("DATA_CRIACAO", TypeName = "datetime")]
    public DateTime? DataCriacao { get; set; }

    [Column("DATA_ADJUDICACAO", TypeName = "datetime")]
    public DateTime? DataAdjudicacao { get; set; }

    [Column("CRIADA_POR")]
    public int? CriadaPor { get; set; }

    [Column("VALOR_ADJUDICACAO", TypeName = "money")]
    public decimal? ValorAdjudicacao { get; set; }

    [Column("ESTADO")]
    
    public string? Estado { get; set; }

    [Column("GESTOR")]
    public int? Gestor { get; set; }

    [Column("INICIO_PREVISTO", TypeName = "datetime")]
    public DateTime? InicioPrevisto { get; set; }

    [Column("FIM_PREVISTO", TypeName = "datetime")]
    public DateTime? FimPrevisto { get; set; }

    [Column("FIM_REAL", TypeName = "datetime")]
    public DateTime? FimReal { get; set; }

    [Column("MORADA")]
    [StringLength(50)]
    public string? Morada { get; set; }

    [Column("LOCALIDADE")]
    [StringLength(50)]
    public string? Localidade { get; set; }

    [Column("CODIGO_POSTAL")]
    [StringLength(15)]
    public string? CodigoPostal { get; set; }

    [Column("LOCAL_POSTAL")]
    [StringLength(50)]
    public string? LocalPostal { get; set; }

    [Column("COND_PAG")]
    [StringLength(2)]
    public string? CondPag { get; set; }

    [Column("MODO_PAG")]
    [StringLength(5)]
    public string? ModoPag { get; set; }

    [Column("OBS")]
    public string? Obs { get; set; }

    [Column("ERP_ID")]
    [StringLength(50)]
    public string? ErpId { get; set; }

    [Column("DELETED")]
    public bool? Deleted { get; set; }

    [Column("PARENT_ID")]
    public int? ParentId { get; set; }

    [Column("VALOR_SECO", TypeName = "decimal(37, 2)")]
    public decimal? ValorSeco { get; set; }

    [Column("VALOR_REORCAMENTO", TypeName = "decimal(37, 2)")]
    public decimal? ValorReorcamento { get; set; }

    [Column("VALOR_TOTAL_EST_MAT", TypeName = "decimal(37, 2)")]
    public decimal? ValorTotalEstMat { get; set; }

    [Column("TOTAL_TMAIS_APROVADOS", TypeName = "decimal(37, 2)")]
    public decimal? TotalTmaisAprovados { get; set; }

    [Column("TOTAL_EO_APROVADOS", TypeName = "decimal(37, 2)")]
    public decimal? TotalEoAprovados { get; set; }

    [Column("TOTAL_REVISAO_PRECOS_APROVADOS", TypeName = "decimal(37, 2)")]
    public decimal? TotalRevisaoPrecosAprovados { get; set; }

    [Column("VALOR_TOTAL_EST_SUBEMPREITADA", TypeName = "decimal(37, 2)")]
    public decimal? ValorTotalEstSubempreitada { get; set; }

    [Column("DESBLOQUEAR_SUBEMPREITADAS")]
    public bool? DesbloquearSubempreitadas { get; set; }

    [Column("PROMOTOR")]
    [StringLength(12)]
    public string? Promotor { get; set; }

    [Column("CONSTRUTOR")]
    [StringLength(12)]
    public string? Construtor { get; set; }

    [Column("ALVARA")]
    [StringLength(50)]
    public string? Alvara { get; set; }

    [Column("VALIDADE_ALVARA", TypeName = "datetime")]
    public DateTime? ValidadeAlvara { get; set; }

    [Column("ISEMPREENDIMENTO")]
    public bool? Isempreendimento { get; set; }

    [Column("PROCESSOID")]
    public int? Processoid { get; set; }

    [Column("EMPRESAID")]
    public int? Empresaid { get; set; }

    [Column("LATITUDE")]
    public double? Latitude { get; set; }

    [Column("LONGITUDE")]
    public double? Longitude { get; set; }

    [Column("AREA")]
    [StringLength(150)]
    public string? Area { get; set; }

}
