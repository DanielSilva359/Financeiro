using Microsoft.AspNetCore.Mvc;
using Domain.Dtos;
using Infra.Repository.Repository.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace FInanceiro.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
        private readonly IBoletoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IBancoRepository _bancoRepository;

        public BoletoController(IBoletoRepository repository, IMapper mapper, IBancoRepository bancoRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _bancoRepository = bancoRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(404, new { type = "InvalidFinanceiroException", message = "Boleto is not found" });
                }

                var boleto = await _repository.GetBoletoById(id);

                decimal totalJuros = 0.00M;

                if (DateTime.Now > boleto.DataVencimento)
                {
                    var banco = await _bancoRepository.GetBancoById(id);

                    if (banco != null)
                    {
                        decimal juros = boleto.Valor * (banco.PercentualJuros / 100);

                        totalJuros = boleto.Valor + juros;
                    }
                }

                var boletoRetorno = _mapper.Map<BoletoDto>(boleto);

                if (boletoRetorno == null)
                {
                    return StatusCode(404, new { type = "InvalidFinanceiroException", message = "Boleto is not found" });
                }

                return StatusCode(200, new { Boleto = boletoRetorno, Juro = totalJuros });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { type = "InternalFinanceiroServerError", message = "Boleto is ServerError: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(AdicionarBoletoDto boletoDto)
        {
            try
            {
                if (string.IsNullOrEmpty(boletoDto.NomePagador) || string.IsNullOrEmpty(boletoDto.CpfCnpjPagador)
                || string.IsNullOrEmpty(boletoDto.NomeBeneficiario) || string.IsNullOrEmpty(boletoDto.CpfCnpfBeneficiario))
                {
                    return StatusCode(400, new { type = "InvalidFinanceiroException", message = "Mandatory information not yet included!" });
                }

                var boletoAdicionar = new Boleto
                {
                    NomePagador = boletoDto.NomePagador,
                    CpfCnpjPagador = boletoDto.CpfCnpjPagador,
                    NomeBeneficiario = boletoDto.NomeBeneficiario,
                    CpfCnpfBeneficiario = boletoDto.CpfCnpfBeneficiario,
                    Valor = boletoDto.Valor,
                    Observacao = boletoDto.Observacao,
                    BancoId = boletoDto.BancoId,
                    DataVencimento = boletoDto.DataVencimento
                };

                _repository.Add(boletoAdicionar);

                if (await _repository.SaveChangesAsync())
                {
                    return StatusCode(201, boletoAdicionar);
                }

                return StatusCode(500, new { type = "InternalFinanceiroServerError", message = "Boleto is ServerError: " });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { type = "InternalFinanceiroServerError", message = "Boleto is ServerError: " + ex.Message });
            }
        }
    }
}
