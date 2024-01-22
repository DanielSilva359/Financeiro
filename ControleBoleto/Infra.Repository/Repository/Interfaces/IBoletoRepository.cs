using Domain.Dtos;
using Domain.Entities;

namespace Infra.Repository.Repository.Interfaces
{
    public interface IBoletoRepository : IBaseRepository
    {
        Task<IEnumerable<BoletoDto>> GetBoletos();
        Task<Boleto> GetBoletoById(int id);
    }
}
