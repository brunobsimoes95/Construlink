namespace Construlink.Models
{
    public class FuncionarioFerias
    {
        public int Id { get; set; }

        public int IdFuncionario { get; set; }
        
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

    }
}
