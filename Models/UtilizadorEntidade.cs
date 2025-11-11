using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Construlink.Models;

[Table("UtilizadorEntidade")]
public class UtilizadorEntidade
{
    [Key]
    public int Id { get; set; }

    public int EntidadeId { get; set; }

    public int UtilizadorId { get; set; }
}

