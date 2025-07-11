using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("UtilizadorEmpresa")]
public partial class UtilizadorEmpresa
{
    [Key]
    public int Id { get; set; }

    public int EmpresaId { get; set; }

    public int UtilizadorId { get; set; }
}
