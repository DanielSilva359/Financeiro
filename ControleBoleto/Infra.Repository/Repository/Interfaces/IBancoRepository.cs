using Domain.Dtos;
using Domain.Entities;

namespace Infra.Repository.Repository.Interfaces
{
    public interface IBancoRepository : IBaseRepository
    {
        Task<IEnumerable<BancoDto>> GetBancos();
        Task<Banco> GetBancoByCodigoBanco(string codigoBanco);
        Task<Banco> GetBancoById(int id);
    }
}
