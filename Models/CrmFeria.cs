using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_FERIAS")]
public partial class CrmFeria
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("DATA")]
    public DateOnly? Data { get; set; }
}
