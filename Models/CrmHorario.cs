using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_HORARIO")]
public partial class CrmHorario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("tipo")]
    [StringLength(50)]
    public string? Tipo { get; set; }

    [Column("data", TypeName = "datetime")]
    public DateTime? Data { get; set; }

    [Column("day_of_week")]
    [StringLength(3)]
    public string? DayOfWeek { get; set; }

    [Column("start_time")]
    public TimeOnly StartTime { get; set; }

    [Column("end_time")]
    public TimeOnly EndTime { get; set; }

    [Column("ispausa")]
    public bool? Ispausa { get; set; }

    [Column("userid")]
    public int? Userid { get; set; }

    [Column("sabado")]
    public bool? Sabado { get; set; }

    [Column("domingo")]
    public bool? Domingo { get; set; }
}
