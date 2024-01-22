using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Infra.Repository.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FInanceiro.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly IBancoRepository _repository;
        private readonly IMapper _mapper;

        public BancoController(IBancoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{codigoBanco}")]
        public async Task<IActionResult> Get(string codigoBanco)
        {
            try
            {
                if (string.IsNullOrEmpty(codigoBanco))
                {
                    return StatusCode(404, new { type = "InvalidFinanceiroException", message = "Banco is not found" });
                }

                var banco = await _repository.GetBancoByCodigoBanco(codigoBanco);

                var bancoRetorno = _mapper.Map<BancoDto>(banco);

                if (bancoRetorno == null)
                {
                    return StatusCode(404, new { type = "InvalidFinanceiroException", message = "Banco is not found" });
                }

                return StatusCode(200, bancoRetorno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { type = "InternalFinanceiroServerError", message = "Banco is ServerError: " + ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var banco = await _repository.GetBancos();

                if (banco.Any())
                {
                    return StatusCode(200, banco);
                }

                return StatusCode(404, new { type = "InvalidFinanceiroException", message = "Bancos is not found" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { type = "InternalFinanceiroServerError", message = "Banco is ServerError: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(AdicionarBancoDto bancoDto)
        {
            try
            {
                if (string.IsNullOrEmpty(bancoDto.NomeBanco) || string.IsNullOrEmpty(bancoDto.CodigoBanco))
                {
                    return StatusCode(400, new { type = "InvalidFinanceiroException", message = "Mandatory information not yet included!" });
                }

                var bancoAdicionar = new Banco
                {
                    NomeBanco = bancoDto.NomeBanco,
                    CodigoBanco = bancoDto.CodigoBanco,
                    PercentualJuros = bancoDto.PercentualJuros
                };

                _repository.Add(bancoAdicionar);

                if (await _repository.SaveChangesAsync())
                {
                    return StatusCode(201, bancoAdicionar);
                }

                return StatusCode(500, new { type = "InternalFinanceiroServerError", message = "Banco is ServerError: " });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { type = "InternalFinanceiroServerError", message = "Banco is ServerError: " + ex.Message });
            }
        }
    }
}
