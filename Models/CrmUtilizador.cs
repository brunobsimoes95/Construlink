using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

[Table("CRM_UTILIZADOR")]
public partial class CrmUtilizador
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("NAME")]
    [StringLength(100)]
    public string? Name { get; set; }

    [Column("USERNAME")]
    [StringLength(250)]
    public string? Username { get; set; }

    [Column("PASSWORD")]
    [StringLength(50)]
    public string? Password { get; set; }

    [Column("EMAIL")]
    [StringLength(250)]
    public string? Email { get; set; }

    [Column("ISACTIVE")]
    public bool? Isactive { get; set; }

    [Column("ISADMIN")]
    public bool? Isadmin { get; set; } = false;

    [Column("LASTLOGON", TypeName = "datetime")]
    public DateTime? Lastlogon { get; set; }

    [Column("CHANGEPASSWORD")]
    public bool? Changepassword { get; set; }

    [Column("ISMANAGER")]
    public bool? Ismanager { get; set; }

    [Column("REPORTTO")]
    public int? Reportto { get; set; }

    [Column("MACADDRESS")]
    [StringLength(50)]
    public string? Macaddress { get; set; }

    [Column("PIN")]
    [StringLength(50)]
    public string? Pin { get; set; }

    [Column("FAZ_PICAGENS")]
    public bool? FazPicagens { get; set; }

    [Column("FUNCONARIO")]
    [StringLength(50)]
    public string? Funconario { get; set; }

    [Column("USER_CF")]
    [StringLength(50)]
    public string? UserCf { get; set; }

    [Column("PREENCHE_TS")]
    public bool? PreencheTs { get; set; }

    [Column("INICIO_TIMESHEETS", TypeName = "datetime")]
    public DateTime? InicioTimesheets { get; set; }

    [Column("DEPARTAMENTO")]
    [StringLength(50)]
    public string? Departamento { get; set; }

    [Column("AGPASSWORD")]
    [StringLength(50)]
    public string? Agpassword { get; set; }

    [Column("EMPRESA")]
    [StringLength(50)]
    public string? Empresa { get; set; }

    [Column("VALIDA_PICAGENS")]
    public bool? ValidaPicagens { get; set; }

    [Column("BANCO_HORAS")]
    public bool? BancoHoras { get; set; }

    [Column("BANCO_HORAS_DATA", TypeName = "datetime")]
    public DateTime? BancoHorasData { get; set; }

    [Column("BANCO_HORAS_START", TypeName = "decimal(10, 1)")]
    public decimal? BancoHorasStart { get; set; }

    [Column("BANCO_HORAS_TURNO", TypeName = "decimal(10, 1)")]
    public decimal? BancoHorasTurno { get; set; }

    [Column("GEOLOCATION")]
    public bool? Geolocation { get; set; }

    [Column("PIN2")]
    [StringLength(50)]
    public string? Pin2 { get; set; }

    [Column("IS_DELETED")]
    public bool? IsDeleted { get; set; } = false;
    public string? NomeTurno { get; set; }
    public int? IdTurno { get; set; }

    [Column("IS_SUPER_ADMIN")]
    public bool? IsSuperAdmin { get; set; } = false;

    [Column("IsApenasPicagens")]
    public bool? IsApenasPicagens { get; set; } = false;

    
    [Column("IsCliente")]
    public bool? IsCliente { get; set; }

    [Column("IsPromotor")]
    public bool? IsPromotor { get; set; }

    [Column("IsVendedor")]
    public bool? IsVendedor { get; set; }

    [Column("IsConstrutor")]
    public bool? IsConstrutor { get; set; }

    [Column("IsGestorObra")]
    public bool? IsGestorObra { get; set; }

    [Column("IsFuncionario")]
    public bool? IsFuncionario { get; set; } = false;


}
