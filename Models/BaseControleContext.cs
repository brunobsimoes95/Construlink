using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Construlink.Models;

public partial class BaseControleContext : DbContext
{
    public BaseControleContext()
    {
    }

    public BaseControleContext(DbContextOptions<BaseControleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CrmAuditorium> CrmAuditoria { get; set; }

    public virtual DbSet<CrmConfig> CrmConfigs { get; set; }

    public virtual DbSet<CrmEmpresa> CrmEmpresas { get; set; }

    public virtual DbSet<CrmUtilizador> CrmUtilizadors { get; set; }

    public virtual DbSet<CrmUtilizadorFacial> CrmUtilizadorFacials { get; set; }

    public virtual DbSet<UtilizadorEmpresa> UtilizadorEmpresas { get; set; }

    public virtual DbSet<Avisos> Avisos { get; set; }

    public virtual DbSet<PatchNotes> PatchNotes { get; set; }

    public virtual DbSet<Manutencoes> Manutencoes { get; set; }


    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////    
    public virtual DbSet<EstadoManutencao> EstadoManutencao { get; set; }

    public virtual DbSet<UtilizadorEntidade> UtilizadorEntidades { get; set; }

    public virtual DbSet<CrmSerieDocumento> CrmSerieDocumentos { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=BaseControle;Trusted_Connection=True;TrustServerCertificate=True;");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
