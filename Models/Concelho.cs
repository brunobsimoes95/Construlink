using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Keyless]
[Table("concelhos")]
public class Concelho
{
    [Column("cod_distrito")]
    public byte CodDistrito { get; set; }

    [Column("cod_concelho")]
    public byte CodConcelho { get; set; }

    [Column("nome_concelho"), MaxLength(50)]
    public string NomeConcelho { get; set; } = null!;
}