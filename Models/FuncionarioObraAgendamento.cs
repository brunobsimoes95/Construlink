using System.ComponentModel.DataAnnotations.Schema;

namespace Construlink.Models
{

    [Table("FuncionarioObraAgendamento")]
    public class FuncionarioObraAgendamento
    {
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public string NomeFuncionario { get; set; } = string.Empty;
        public int IdObra { get; set; }
        public string NomeObra { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime DataFim { get; set; } = DateTime.Now;
        public TimeSpan? HoraEntrada { get; set; }
        public TimeSpan? HoraPausa { get; set; }
        public TimeSpan? HoraRetorno { get; set; }
        public double? HorasNormais { get; set; }
        public double? HorasExtras { get; set; }
        public TimeSpan? HoraSaida { get; set; }
        public bool? Trabalhou { get; set; }
        public bool? FaltouParcialmente { get; set; }
        

    }
}
