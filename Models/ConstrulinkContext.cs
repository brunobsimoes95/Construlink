using Microsoft.EntityFrameworkCore;

namespace Construlink.Models
{
    public partial class ConstrulinkContext : DbContext
    {
        public ConstrulinkContext()
        {
        }

        public ConstrulinkContext(DbContextOptions<ConstrulinkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CrmConfig> CrmConfigs { get; set; }

        public virtual DbSet<CrmFalta> CrmFaltas { get; set; }

        public virtual DbSet<CrmFeria> CrmFerias { get; set; }

        public virtual DbSet<CrmFeriado> CrmFeriados { get; set; }

        //public virtual DbSet<CrmFuncionarioDetalhe> CrmFuncionarios { get; set; }

        public virtual DbSet<CrmHorario> CrmHorarios { get; set; }

        public virtual DbSet<CrmPicagem> CrmPicagems { get; set; }

        public virtual DbSet<TipoTurno> TipoTurno { get; set; }

        public virtual DbSet<Turnos> Turnos { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  
        public virtual DbSet<CrmPaise> CrmPaises { get; set; }

        public virtual DbSet<CrmDistrito> CrmDistritos { get; set; }

        public virtual DbSet<CrmConcelho> CrmConcelhos { get; set; }

        public virtual DbSet<CrmPrazoPagamento> CrmPrazosPagamento { get; set; }

        public virtual DbSet<CrmTipoDocumento> CrmTipoDocumentos  { get; set; }

        public virtual DbSet<CrmSerieDocumento> CrmSerieDocumentos { get; set; }

        public virtual DbSet<CrmMotivosisencao> CrmMotivosisencaos { get; set; }

        public virtual DbSet<NiveisPreco> NiveisPrecos { get; set; }

        public virtual DbSet<CrmEntidade> CrmEntidades { get; set; }

        public virtual DbSet<CrmEntidadeMetum> CrmEntidadeMetas { get; set; }

        public virtual DbSet<OsusrN2pCondpagamento> OsusrN2PCondpagamentos  { get; set; }

        public virtual DbSet<OsusrN2pEntidadesErp> OsusrN2PEntidadesErps { get; set; }

        public virtual DbSet<OsusrN2pEstado> OsusrN2PEstados { get; set; }

        public virtual DbSet<OsusrN2pFraco> OsusrN2PFracos { get; set; }

        public virtual DbSet<OsusrN2pImobiliariasObra> OsusrN2PImobiliariasObras { get; set; }

        public virtual DbSet<OsusrN2pModospagamento> OsusrN2PModospagamentos { get; set; }

        public virtual DbSet<OsusrN2pObra> OsusrN2PObras { get; set; }

        public virtual DbSet<OsusrN2pProcesso> OsusrN2PProcessos { get; set; }

        public virtual DbSet<FuncionarioObraAgendamento> FuncionarioObraAgendamentos { get; set; }

        public virtual DbSet<Epis> Epis { get; set; }

        public virtual DbSet<ColaboradorEPI> ColaboradorEPIs { get; set; }

        public virtual DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<CrmEmpresa> CrmEmpresas { get; set; }

        public virtual DbSet<Contrato> Contratos { get; set; }

        public virtual DbSet<Distrito> Distritos { get; set; }

        public virtual DbSet<Concelho> Concelhos { get; set; }

        public virtual DbSet<CodigoPostal> CodigoPostals { get; set; }

        public DbSet<FuncionarioFerias> FuncionarioFerias { get; set; }

        public DbSet<CrmAusencia> CrmAusencias { get; set; }
        public virtual DbSet<CrmAnexo> CrmAnexos { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=localhost;Database=Construlink;Trusted_Connection=True;TrustServerCertificate=True;");


    }
}
