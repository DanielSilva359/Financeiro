namespace Domain.Entities
{
    public class Banco : Base
    {
        public string? NomeBanco { get; set; }
        public string? CodigoBanco { get; set; }
        public decimal PercentualJuros { get; set; } = 0.00M;

    }
}
