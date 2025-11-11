using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

public partial class Funcionario
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Abreviatura { get; set; }

    [StringLength(250)]
    public string? Nome { get; set; }

    [Column("IDFuncao")]
    public int? Idfuncao { get; set; }

    [StringLength(3)]
    public string? OrdemMapas { get; set; }

    [Column("CustoHora", TypeName = "decimal(18, 2)")]
    public decimal? CustoHora { get; set; }

    public bool? Comercial { get; set; }

    public int? MontagensResponsavel { get; set; }

    public int? MontagensFuncionarios { get; set; }

    [StringLength(250)]
    public string? Email { get; set; }

    [Column("IDComissoesTabela")]
    public int? IdcomissoesTabela { get; set; }

    [StringLength(100)]
    public string? Senha { get; set; }

    public int? SenhaProvisoria { get; set; }

    public int? Inativo { get; set; }

    [Column("USERNAME")]
    [StringLength(250)]
    public string? Username { get; set; }

    [Column("PASSWORD")]
    [StringLength(50)]
    public string? Password { get; set; }

    [Column("ISACTIVE")]
    public bool? Isactive { get; set; }

    [Column("ISADMIN")]
    public bool? Isadmin { get; set; }

    [Column("IsChaoFabrica")]
    public bool? IsChaoFabrica { get; set; } = false;

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

    [Column("ACEDE_OBRAS")]
    public bool? AcedeObras { get; set; }

    [Column("ACEDE_ENTIDADES")]
    public bool? AcedeEntidades { get; set; }

    public bool? AcedeComercial { get; set; }

    public bool? IsFuncionario { get; set; }

    public bool? AcedeArtigos { get; set; }

    [StringLength(10)]
    public string? Codigo { get; set; }

    [Column("veValore")]
    public bool? VeValore { get; set; }

    [Column("acede_documentos")]
    public bool? AcedeDocumentos { get; set; }

    [Column("so_obras")]
    public bool? SoObras { get; set; }

    [StringLength(100)]
    public string? NomeCompleto { get; set; }

    [StringLength(200)]
    public string? Morada { get; set; }

    [StringLength(50)]
    public string? Concelho { get; set; }

    [StringLength(100)]
    public string? Localidade { get; set; }

    [StringLength(100)]
    public string? CodPostal { get; set; }

    [StringLength(50)]
    public string? Telefone { get; set; }

    [StringLength(50)]
    public string? ContatoSeguranca { get; set; }

    [StringLength(50)]
    public string? Nif { get; set; }

    [Column("CC")]
    [StringLength(50)]
    public string? Cc { get; set; }

    [StringLength(50)]
    public string? SegSocial { get; set; }

    [Column("CCValidade", TypeName = "datetime")]
    public DateTime? Ccvalidade { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataNascimento { get; set; }

    [StringLength(50)]
    public string? EstadoCivil { get; set; }

    public int? NumFilhos { get; set; }

    [StringLength(100)]
    public string? Seguro { get; set; }

    [Column("IBAN")]
    [StringLength(100)]
    public string? Iban { get; set; }

    [Column("NIB")]
    [StringLength(100)]
    public string? Nib { get; set; }

    [StringLength(100)]
    public string? Swift { get; set; }

    [StringLength(250)]
    public string? HabilitacoesLiterarias { get; set; }

    [Column("ACEDE_CONTASCORRENTES")]
    public bool? AcedeContascorrentes { get; set; }

    [Column("ADJUDICA_OBRA")]
    public bool? AdjudicaObra { get; set; }

    [Column("IdCrmUtilizador")]
    public int? IdUtilizador { get; set; }

    [Column("NumMecanografico")]
    public int? NumMecanografico { get; set; }

    [Column("Observacoes")]
    public string? Obs { get; set; }

    public string? CaminhoFoto { get; set; }
}