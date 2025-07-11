using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Construlink.Data;

namespace Construlink.Models;

[Table("CRM_DOCUMENTO")]
public partial class CrmDocumento
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("NUMERO")]
    public int? Numero { get; set; }

    [Column("DATA", TypeName = "datetime")]
    public DateTime? Data { get; set; }

    [Column("VENCIMENTO", TypeName = "datetime")]
    public DateTime? Vencimento { get; set; }

    [Column("DESCONTO", TypeName = "decimal(18, 4)")]
    public decimal? Desconto { get; set; }

    [Column("T_ILIQUIDO", TypeName = "decimal(18, 2)")]
    public decimal? TIliquido { get; set; }

    [Column("T_DESCONTO", TypeName = "decimal(18, 2)")]
    public decimal? TDesconto { get; set; }

    [Column("T_IVA", TypeName = "decimal(18, 2)")]
    public decimal? TIva { get; set; }

    [Column("T_LIQUIDO", TypeName = "decimal(18, 2)")]
    public decimal? TLiquido { get; set; }

    [Column("OBSERVACOES")]
    public string? Observacoes { get; set; }

    [Column("NOTAS")]
    public string? Notas { get; set; }

    [Column("IDINTEGRACAO")]
    [StringLength(50)]
    public string? Idintegracao { get; set; }

    [Column("FECHADO")]
    public bool? Fechado { get; set; }

    [Column("ATUALIZADOEM", TypeName = "datetime")]
    public DateTime? Atualizadoem { get; set; }

    [Column("NOME")]
    [StringLength(100)]
    public string? Nome { get; set; }

    [Column("MORADA")]
    [StringLength(100)]
    public string? Morada { get; set; }

    [Column("LOCALIDADE")]
    [StringLength(100)]
    public string? Localidade { get; set; }

    [Column("NIF")]
    [StringLength(25)]
    public string? Nif { get; set; }

    [Column("DESC_VAL_PERC")]
    [StringLength(1)]
    public string? DescValPerc { get; set; }

    [Column("ANULADO")]
    public bool? Anulado { get; set; }

    [Column("CRIADOPOR")]
    public int? Criadopor { get; set; }

    [Column("TIPODOCUMENTOID")]
    public int? Tipodocumentoid { get; set; }

    [Column("SERIEID")]
    public int? Serieid { get; set; }

    [Column("ENTIDADEID")]
    public int? Entidadeid { get; set; }

    [Column("CODIGOPOSTAL")]
    [StringLength(100)]
    public string? Codigopostal { get; set; }

    [Column("PAISID")]
    public int? Paisid { get; set; }

    [Column("DATAANULACAO", TypeName = "datetime")]
    public DateTime? Dataanulacao { get; set; }

    [Column("ANULADOPOR")]
    public int? Anuladopor { get; set; }

    [Column("ARMAZEMORIGEM")]
    public int? Armazemorigem { get; set; }

    [Column("ARMAZEM_DESTINO")]
    public int? ArmazemDestino { get; set; }

    [Column("LOTE")]
    [StringLength(50)]
    public string? Lote { get; set; }

    [Column("LOJAID")]
    public int? Lojaid { get; set; }

    [Column("UTILIZADORID")]
    public int? Utilizadorid { get; set; }

    [Column("MODULO")]
    [StringLength(1)]
    public string? Modulo { get; set; }

    [Column("LINKPDF")]
    public string? Linkpdf { get; set; }

    [Column("MENSAGEM")]
    public string? Mensagem { get; set; }

    [Column("NUMDOCERP")]
    [StringLength(50)]
    public string? Numdocerp { get; set; }

    [Column("ASSISTENCIAID")]
    public int? Assistenciaid { get; set; }

    [Column("MOTIVOANULACAOID")]
    public int? Motivoanulacaoid { get; set; }

    [Column("DOCUMENTOORIGEM")]
    public int? Documentoorigem { get; set; }

    [Column("CERTIFICADOAT")]
    [StringLength(250)]
    public string? Certificadoat { get; set; }

    [Column("CONDPAGAMENTO")]
    public int? Condpagamento { get; set; }

    [Column("OLD_DOC_ID")]
    [StringLength(50)]
    public string? OldDocId { get; set; }

    [Column("REFERENCIA")]
    [StringLength(50)]
    public string? Referencia { get; set; }

    [Column("DATA_ENTREGA", TypeName = "datetime")]
    public DateTime? DataEntrega { get; set; }

    [Column("DATA_CARGA", TypeName = "datetime")]
    public DateTime? DataCarga { get; set; }

    [Column("DATA_DESCARGA", TypeName = "datetime")]
    public DateTime? DataDescarga { get; set; }

    [Column("LOCAL_CARGA")]
    [StringLength(150)]
    public string? LocalCarga { get; set; }

    [Column("LOCAL_DESCARGA")]
    [StringLength(150)]
    public string? LocalDescarga { get; set; }

    [Column("CodigoObra")]
    [StringLength(50)]
    public string? CodigoObra { get; set; }

    [Column("MANUTENCAOID")]
    public int? Manutencaoid { get; set; }

    [Column("INSTALACAOID")]
    public int? Instalacaoid { get; set; }

    [Column("ADJUDICADO")]
    public bool? Adjudicado { get; set; }

    [Column("EMAILENVIADO")]
    public bool? Emailenviado { get; set; }

    [Column("ORCAMENTOID")]
    public int? Orcamentoid { get; set; }

    [Column("PORTES", TypeName = "decimal(37, 8)")]
    public decimal? Portes { get; set; }

    [Column("ADIANTAMENTOS", TypeName = "decimal(37, 8)")]
    public decimal? Adiantamentos { get; set; }

    [Column("INCOTERM")]
    public int? Incoterm { get; set; }

    [Column("DATA_PEDIDO")]
    public DateOnly? DataPedido { get; set; }

    [Column("REFPEDCOT")]
    [StringLength(50)]
    public string? Refpedcot { get; set; }

    [Column("NOSSOORCAMENTO")]
    [StringLength(50)]
    public string? Nossoorcamento { get; set; }

    [Column("DOCUMENTO_ORDEM_FABRICO")]
    public int? DocumentoOrdemFabrico { get; set; }

    [Column("MARGEMSEGURANCA")]
    public int? Margemseguranca { get; set; }

    [Column("TIPO_PALETE")]
    public int? TipoPalete { get; set; }

    [Column("HORA_ENTREGA")]
    public int? HoraEntrega { get; set; }

    [Column("MIN_ENTREGA")]
    public int? MinEntrega { get; set; }

    [Column("MATRICULA")]
    [StringLength(50)]
    public string? Matricula { get; set; }

    [Column("RECUSADO")]
    public bool? Recusado { get; set; }

    [Column("HORA_CARGA")]
    public int? HoraCarga { get; set; }

    [Column("MIN_CARGA")]
    public int? MinCarga { get; set; }

    [Column("DELETED")]
    public bool? Deleted { get; set; }

    [Column("MERCADO")]
    public int? Mercado { get; set; }

    [Column("TEMP_PREVTRANS", TypeName = "decimal(10, 2)")]
    public decimal? TempPrevtrans { get; set; }

    [Column("ESTADO")]
    public int? Estado { get; set; }

    [Column("CAIXA_CLIENTE")]
    [StringLength(45)]
    public string? CaixaCliente { get; set; }

    [Column("NomeNivelCliente")]
    [StringLength(100)]
    public string? NomeNivelCliente { get; set; }

    [Column("T_DESCONTOF", TypeName = "decimal(18, 2)")]
    public decimal? TDescontof { get; set; }

    [Column("DESCONTOF", TypeName = "decimal(18, 2)")]
    public decimal? Descontof { get; set; }

    [Column("DESCONTOC", TypeName = "decimal(18, 2)")]
    public decimal? Descontoc { get; set; }

    [Column("T_ECO", TypeName = "decimal(18, 2)")]
    public decimal? TEco { get; set; }
    public bool? IsIsento { get; set; } = false;
    public int? IdNivelCliente { get; set; }

    [Column("DocIva", TypeName = "decimal(18, 2)")]
    public decimal? DocIva { get; set; }

    [Column("CodigoIva")]
    [StringLength(200)]
    public string? CodigoIva { get; set; }

}
