namespace Domain.Dtos
{
    public class BancoDto
    {
        public int Id { get; set; }
        public string? NomeBanco { get; set; }
        public string? CodigoBanco { get; set; }
        public decimal PercentualJuros { get; set; } = 0.00M;
    }
}
