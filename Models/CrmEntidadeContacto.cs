using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_ENTIDADE_CONTACTO")]
public partial class CrmEntidadeContacto
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("TIPO_CONTACTO")]
    [StringLength(50)]
    public string? TipoContacto { get; set; }

    [Column("EMAIL")]
    [StringLength(250)]
    public string? Email { get; set; }

    [Column("ENTIDADEID")]
    public int? Entidadeid { get; set; }

    [Column("NOME")]
    [StringLength(50)]
    public string? Nome { get; set; }

    [Column("CONTACTO")]
    [StringLength(50)]
    public string? Contacto { get; set; }

    [Column("RECEBE_EMAIL")]
    public bool? RecebeEmail { get; set; }

    [Column("TELEMOVEL")]
    [StringLength(50)]
    public string? Telemovel { get; set; }

    [Column("OBS")]
    [StringLength(250)]
    public string? Obs { get; set; }
}
