using Infra.Repository.Context;
using Domain.Dtos;
using Infra.Repository.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infra.Repository.Repository
{
    public class BoletoRepository : BaseRepository, IBoletoRepository
    {
        private readonly FinanceiroContext _context;

        public BoletoRepository(FinanceiroContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BoletoDto>> GetBoletos()
        {
            return await _context.Boletos
                .Select(x => new BoletoDto
                {
                    Id = x.Id,
                    NomePagador = x.NomePagador
                ,
                    CpfCnpjPagador = x.CpfCnpjPagador,
                    CpfCnpfBeneficiario = x.CpfCnpfBeneficiario
                ,
                    NomeBeneficiario = x.NomeBeneficiario,
                    Valor = x.Valor,
                    DataVencimento = x.DataVencimento
                ,
                    Observacao = x.Observacao,
                    BancoId = x.BancoId
                })
                .ToListAsync();
        }

        public async Task<Boleto> GetBoletoById(int id)
        {
            return await _context.Boletos
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
