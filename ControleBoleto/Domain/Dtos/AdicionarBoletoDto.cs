namespace Domain.Dtos
{
    public class AdicionarBoletoDto
    {
        public string? NomePagador { get; set; }
        public string? CpfCnpjPagador { get; set; }
        public string? NomeBeneficiario { get; set; }
        public string? CpfCnpfBeneficiario { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Observacao { get; set; } = "";
        public int BancoId { get; set; }
    }
}
