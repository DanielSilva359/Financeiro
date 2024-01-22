using Domain.Dtos;
using Domain.Entities;
using Infra.Repository.Context;
using Infra.Repository.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository.Repository
{
    public class BancoRepository : BaseRepository, IBancoRepository
    {
        private readonly FinanceiroContext _context;

        public BancoRepository(FinanceiroContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Banco> GetBancoById(int id)
        {
            return await _context.Bancos
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Banco> GetBancoByCodigoBanco(string codigoBanco)
        {
            return await _context.Bancos
                .Where(x => x.CodigoBanco == codigoBanco)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BancoDto>> GetBancos()
        {
            return await _context.Bancos
                .Select(x => new BancoDto
                {
                    Id = x.Id,
                    CodigoBanco = x.CodigoBanco
                ,
                    NomeBanco = x.NomeBanco
                ,
                    PercentualJuros = x.PercentualJuros
                })
                .ToListAsync();
        }
    }
}
