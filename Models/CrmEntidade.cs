using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_ENTIDADE")]
public partial class CrmEntidade
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("codigo")]
    [StringLength(500)]
    public string? Codigo { get; set; }

    [Column("nome")]
    [StringLength(500)]
    public string? Nome { get; set; }

    [Column("nome_fiscal")]
    [StringLength(500)]
    public string? NomeFiscal { get; set; }

    [Column("situacao")]
    [StringLength(50)]
    public string? Situacao { get; set; }

    [Column("tipo_preco")]
    [StringLength(5)]
    public string? TipoPreco { get; set; }

    [Column("email")]
    [StringLength(255)]
    public string? Email { get; set; }

    [Column("site")]
    [StringLength(255)]
    public string? Site { get; set; }

    [Column("NomeNivelPreco")]
    [StringLength(100)]
    public string? NomeNivelPreco { get; set; }
    public int? NivelPreco { get; set; }

    [Column("zona")]
    [StringLength(255)]
    public string? Zona { get; set; }

    [Column("vendedor")]
    [StringLength(45)]
    public string? Vendedor { get; set; }

    [Column("morada")]
    [StringLength(255)]
    public string? Morada { get; set; }

    [Column("morada2")]
    [StringLength(255)]
    public string? Morada2 { get; set; }

    [Column("localidade")]
    [StringLength(255)]
    public string? Localidade { get; set; }

    [Column("CpLoc")]
    [StringLength(255)]
    public string? CpLoc { get; set; }

    [Column("TipoMercado")]
    [StringLength(5)]
    public string? TipoMercado { get; set; }

    [Column("Moeda")]
    [StringLength(50)]
    public string? Moeda { get; set; }

    [Column("IdPrimavera")]
    [StringLength(12)]
    public string? IdPrimavera { get; set; }

    [Column("codigo_postal")]
    [StringLength(45)]
    public string? CodigoPostal { get; set; }

    [Column("pais")]
    [StringLength(100)]
    public string? Pais { get; set; }

    [Column("telefone")]
    [StringLength(45)]
    public string? Telefone { get; set; }

    [Column("telemovel")]
    [StringLength(45)]
    public string? Telemovel { get; set; }

    [Column("nif")]
    [StringLength(45)]
    public string? Nif { get; set; }

    [Column("data_upd", TypeName = "datetime")]
    public DateTime? DataUpd { get; set; }

    [Column("isactive")]
    public bool Isactive { get; set; }

    [Column("distrito")]
    public int? Distrito { get; set; }

    [Column("concelho")]
    public int? Concelho { get; set; }

    [Column("cond_Pagamento")]
    public int? CondPagamento { get; set; }

    [Column("tipo_entidade")]
    [StringLength(1)]
    public string? TipoEntidade { get; set; }

    [Column("observacoes")]
    public string? Observacoes { get; set; }

    [Column("nib")]
    [StringLength(50)]
    public string? Nib { get; set; }

    [Column("iban")]
    [StringLength(50)]
    public string? Iban { get; set; }

    [Column("swift")]
    [StringLength(50)]
    public string? Swift { get; set; }

    [Column("plafond", TypeName = "numeric(18, 3)")]
    public decimal? Plafond { get; set; }

    [Column("fax")]
    [StringLength(45)]
    public string? Fax { get; set; }

    [Column("isentoiva")]
    public bool? Isentoiva { get; set; }

    [Column("motivoisencao")]
    public int? Motivoisencao { get; set; }

    [Column("IsPotencial")]
    public bool? IsPotencial { get; set; }

    [Column("ccEntidade")]
    public string? Ccentidade { get; set; }

    [Column("ccValidade")]
    public DateTime? CcValidade { get; set; }
}
