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
    public class TituloController : ControllerBase
    {
        private readonly ITituloRepository _tituloRepository;

        public TituloController(ITituloRepository tituloRepository)
        {
            _tituloRepository = tituloRepository;
        }

        // GET: api/<TituloController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Titulo>>> Selecionar([FromQuery] int cliente, int formapagamento, int numparcela, string? status, string? opcaodata, DateTime datainicial, DateTime datafinal, string? ordenar )
        {
            try
            {
                var Titulos = await _tituloRepository.Selecionar( cliente, formapagamento, numparcela, status, opcaodata, datainicial, datafinal, ordenar);

                if (Titulos is null)
                {
                    return NotFound("Nenhum Registro Encontrado");
                }

                return Ok(Titulos);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        // GET api/<TituloController>/5
        [HttpGet("{id}", Name = "GetTitulo")]
        public async Task<ActionResult<Titulo>> SelecionarId(int id)
        {
            try
            {
                var titulo = await _tituloRepository.SelecionarId(id);

                if (titulo is null)
                {
                    return NotFound("Titulo não Encontrado");
                }

                return Ok(titulo);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        // POST api/<TituloController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Titulo titulo)
        {
            if (titulo == null)
                return BadRequest("Dados Invalido");

            await _tituloRepository.Cadastrar(titulo);

            return new CreatedAtRouteResult("GetTitulo",
                new { id = titulo.Id }, titulo);
        }

        // PUT api/<TituloController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Titulo>> Put(int id, Titulo titulo)
        {
            if (titulo == null)
                return BadRequest("Dados invalidos");

            if (id != titulo.Id)
            {
                return BadRequest("Assinatura invalida");
            }

            await _tituloRepository.Alterar(id, titulo);

            return Ok(titulo);
        }

        // DELETE api/<TituloController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Titulo>> Delete(int id)
        {
            try
            {
                var titulo = await _tituloRepository.SelecionarId(id);

                if (titulo is null)
                {
                    return NotFound("Registro não Encontrado");
                }

                await _tituloRepository.Cancelar(id);

                return Ok(titulo);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }

        }
    }
}
