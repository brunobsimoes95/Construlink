using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Keyless]
[Table("codigos_postais")]
public class CodigoPostal
{
    [Column("cod_distrito")]
    public byte CodDistrito { get; set; }

    [Column("cod_concelho")]
    public byte CodConcelho { get; set; }

    [Column("cod_localidade"), MaxLength(250)]
    public string CodLocalidade { get; set; } = null!;

    [Column("nome_localidade"), Required, MaxLength(100)]
    public string NomeLocalidade { get; set; } = null!;

    [Column("cod_arteria")]
    public int? CodArteria { get; set; }

    [Column("tipo_arteria"), MaxLength(30)]
    public string? TipoArteria { get; set; }

    [Column("prep1"), MaxLength(10)] public string? Prep1 { get; set; }
    [Column("titulo_arteria"), MaxLength(40)] public string? TituloArteria { get; set; }
    [Column("prep2"), MaxLength(10)] public string? Prep2 { get; set; }
    [Column("nome_arteria"), MaxLength(120)] public string? NomeArteria { get; set; }
    [Column("local_arteria"), MaxLength(80)] public string? LocalArteria { get; set; }
    [Column("troco"), MaxLength(120)] public string? Troco { get; set; }
    [Column("porta"), MaxLength(20)] public string? Porta { get; set; }
    [Column("cliente"), MaxLength(200)] public string? Cliente { get; set; }

    [Column("num_cod_postal", TypeName = "smallint")]
    public short NumCodPostal { get; set; }      // 4710

    [Column("ext_cod_postal", TypeName = "smallint")]
    public short ExtCodPostal { get; set; }      // 1 (guarda-se sem zeros)

    [Column("desig_postal"), Required, MaxLength(50)]
    public string DesigPostal { get; set; } = null!;

    [NotMapped]                                  // helper de formatação
    public string CodigoCompleto =>
        $"{NumCodPostal:D4}-{ExtCodPostal:D3}";
}