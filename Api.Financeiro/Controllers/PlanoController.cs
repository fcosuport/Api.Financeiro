using Api.Financeiro.Interfaces;
using Api.Financeiro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Financeiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanoController : ControllerBase
    {
        private readonly IPlanoRepository _planoRepository;

        public PlanoController(IPlanoRepository planoRepository)
        {
            _planoRepository = planoRepository;
        }

        // GET: api/<PlanoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plano>>> Listar()
        {
            try
            {
                var planos = await _planoRepository.Listar();

                if (planos is null)
                {
                    return NotFound("Nenhum Plano Encontrado");
                }

                return Ok(planos);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        // GET api/<PlanoController>/5
        [HttpGet("{id}", Name = "GetPlano")]
        public async Task<ActionResult<Plano>> SelecionarId(int id)
        {
            try
            {
                var plano = await _planoRepository.SelecionarId(id);

                if (plano is null)
                {
                    return NotFound("Plano não Encontrado");
                }

                return Ok(plano);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        // POST api/<PlanoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Plano plano)
        {
            if (plano == null)
                return BadRequest("Dados Invalido");

            await _planoRepository.Cadastrar(plano);

            return new CreatedAtRouteResult("GetPlano",
                new { id = plano.Id }, plano);
        }

        // PUT api/<PlanoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Plano>> Put([FromBody] Plano plano)
        {
            if (plano == null)
                return BadRequest("Dados invalidos");

            await _planoRepository.Alterar(plano);

            return Ok(plano);
        }

    }
}
