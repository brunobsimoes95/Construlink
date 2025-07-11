using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Construlink.Data;

namespace Construlink.Models;

[Table("CRM_ARTIGO")]
public class CrmArtigo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("codigo_artigo")]
    [StringLength(20)]
    [Unicode(false)]
    public string CodigoArtigo { get; set; } = null!;

    [Column("artigo")]
    [StringLength(255)]
    public string? Artigo { get; set; }

    [Column("artigo_pai")]
    [StringLength(255)]
    public string? ArtigoPai { get; set; }

    [Column("nome")]
    [StringLength(500)]
    public string? Nome { get; set; }

    [Column("descricao")]
    [StringLength(500)]
    public string? Descricao { get; set; }

    [Column("descricao_abreviada")]
    [StringLength(500)]
    public string? DescricaoAbreviada { get; set; }

    [Column("carateristicas")]
    [StringLength(500)]
    public string? Carateristicas { get; set; }

    [Column("ultimo_custo", TypeName = "decimal(10, 2)")]
    public decimal? UltimoCusto { get; set; }

    [Column("iva_venda")]
    [StringLength(45)]
    public string? IvaVenda { get; set; }

    [Column("stock", TypeName = "decimal(10, 2)")]
    public decimal? Stock { get; set; }

    [Column("custo_padrao", TypeName = "decimal(10, 2)")]
    public decimal? CustoPadrao { get; set; }

    [Column("preco_venda", TypeName = "decimal(10, 2)")]
    public decimal? PrecoVenda { get; set; }

    [Column("data_upd", TypeName = "datetime")]
    public DateTime DataUpd { get; set; }

    [Column("observacoes")]
    public string? Observacoes { get; set; }

    [Column("tipo_artigo")]
    [StringLength(45)]
    public string? TipoArtigo { get; set; }

    [Column("unidade")]
    [StringLength(10)]
    public string? Unidade { get; set; }

    [Column("isactive")]
    public bool Isactive { get; set; }

    [Column("iva_compra")]
    [StringLength(3)]
    public string? IvaCompra { get; set; }

    [Column("stock_minimo", TypeName = "decimal(10, 2)")]
    public decimal? StockMinimo { get; set; }

    [Column("fornecedor_padrao")]
    [StringLength(500)]
    public string? FornecedorPadrao { get; set; }

    [Column("isservice")]
    public bool? Isservice { get; set; }

    [Column("cliente_padrao")]
    [StringLength(500)]
    public string? ClientePadrao { get; set; }

    [Column("tem_gestao")]
    public bool? TemGestao { get; set; }

    [Column("tem_lote")]
    public bool? TemLote { get; set; }

    [Column("armazem_por_defeito")]
    public int? ArmazemPorDefeito { get; set; }

    [Column("margem", TypeName = "decimal(10, 2)")]
    public decimal? Margem { get; set; }

    [Column("preco_venda_liquido", TypeName = "decimal(10, 2)")]
    public decimal? PrecoVendaLiquido { get; set; }

    [Column("margem_seg", TypeName = "decimal(10, 2)")]
    public decimal? MargemSeg { get; set; }

    [Column("tem_prod")]
    public bool? TemProd { get; set; }

    [Column("custo_atual", TypeName = "decimal(10, 2)")]
    public decimal? CustoAtual { get; set; }
}
