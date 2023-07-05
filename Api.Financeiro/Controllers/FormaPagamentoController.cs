using Api.Financeiro.Interfaces;
using Api.Financeiro.Models;
using Api.Financeiro.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Financeiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly IFormaPagamentoRepository _formapagamentoRepository;

        public FormaPagamentoController(IFormaPagamentoRepository formapagamentoRepository)
        {
            _formapagamentoRepository = formapagamentoRepository;
        }

        // GET: api/<FormaPagamentoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormaPagamento>>> Listar()
        {
            try
            {
                var formaspagamentos = await _formapagamentoRepository.Listar();

                if (formaspagamentos is null)
                {
                    return NotFound("Nenhum Registro Encontrado");
                }

                return Ok(formaspagamentos);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        // GET api/<FormaPagamentoController>/5
        [HttpGet("{id}", Name = "GetFormaPagamento")]
        public async Task<ActionResult<FormaPagamento>> SelecionarId(int id)
        {
            try
            {
                var formapagamento = await _formapagamentoRepository.SelecionarId(id);

                if (formapagamento is null)
                {
                    return NotFound("Registro não Encontrado");
                }

                return Ok(formapagamento);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        // POST api/<FormaPagamentoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FormaPagamento formaPagamento)
        {
            if (formaPagamento == null)
                return BadRequest("Dados Invalido");

            await _formapagamentoRepository.Cadastrar(formaPagamento);

            return new CreatedAtRouteResult("GetFormaPagamento",
                new { id = formaPagamento.Id }, formaPagamento);
        }

        // PUT api/<FormaPagamentoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<FormaPagamento>> Put([FromBody] FormaPagamento formaPagamento)
        {
            if (formaPagamento == null)
                return BadRequest("Dados invalidos");

            await _formapagamentoRepository.Alterar(formaPagamento);

            return Ok(formaPagamento);
        }

    }
}
