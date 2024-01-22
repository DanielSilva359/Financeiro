namespace Domain.Dtos
{
    public class AdicionarBancoDto
    {
        public string? NomeBanco { get; set; }
        public string? CodigoBanco { get; set; }
        public decimal PercentualJuros { get; set; } = 0.00M;
    }
}
