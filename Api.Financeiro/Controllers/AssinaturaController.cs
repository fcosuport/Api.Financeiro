using Api.Financeiro.Interfaces;
using Api.Financeiro.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Financeiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssinaturaController : ControllerBase
    {
        private readonly IAssinaturaRepository _assinaturaRepository;
        //private object? assinaturas;

        public AssinaturaController(IAssinaturaRepository assinaturaRepository)
        {
            _assinaturaRepository = assinaturaRepository;
        }

        // GET: api/<AssinaturaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assinatura>>> Selecionar([FromQuery] string? cliente, int produto, int plano, int formapagamento, string? status)
        {
            try
            {

                var assinaturas = await _assinaturaRepository.Selecionar( cliente, produto, plano,formapagamento,status);

                if (assinaturas is null)
                {
                    return NotFound("Nenhum Registro Encontrado");
                }

                /*var jsonSettings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                var json = JsonConvert.SerializeObject(assinaturas, jsonSettings);*/

                //return Content(json, "application/json");
                return Ok(assinaturas);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        // GET api/<AssinaturaController>/5
        [HttpGet("{id}", Name = "GetAssinatura")]
        public async Task<ActionResult<Assinatura>> SelecionarId(int id)
        {
            try
            {
                var assinatura = await _assinaturaRepository.SelecionarId(id);

                if (assinatura is null)
                {
                    return NotFound("Registro não Encontrado");
                }

                return Ok(assinatura);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        // POST api/<AssinaturaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Assinatura assinatura)
        {
            if (assinatura == null)
                return BadRequest("Dados Invalido");

            await _assinaturaRepository.Cadastrar(assinatura);

            return new CreatedAtRouteResult("GetAssinatura",
                new { id = assinatura.Id }, assinatura);
        }

        // PUT api/<AssinaturaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Assinatura>> Put(int id, Assinatura assinatura)
        {
            if (assinatura == null)
                return BadRequest("Dados invalidos");

            if (id != assinatura.Id)
            {
                return BadRequest("Assinatura invalida");
            }

            await _assinaturaRepository.Alterar(id, assinatura);

            return Ok(assinatura);
        }

        // DELETE api/<AssinaturaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Assinatura>> Delete(int id)
        {
            try
            {
                var assinatura = await _assinaturaRepository.SelecionarId(id);

                if (assinatura is null)
                {
                    return NotFound("Registro não Encontrado");
                }

                await _assinaturaRepository.Cancelar(id);

                return Ok(assinatura);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }

        }
    }
}
