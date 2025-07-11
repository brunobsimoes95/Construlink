using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;
[Keyless]
[Table("distritos")]
public class Distrito
{
    [Key]
    [Column("cod_distrito")]
    public byte CodDistrito { get; set; }

    [Required, MaxLength(50)]
    [Column("nome_distrito")]
    public string NomeDistrito { get; set; } = null!;
}
