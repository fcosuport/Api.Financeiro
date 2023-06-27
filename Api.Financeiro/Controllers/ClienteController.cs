using Api.Financeiro.Interfaces;
using Api.Financeiro.Models;
using Api.Financeiro.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Financeiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
        {
            try
            {
                var Clientes = await _clienteRepository.Listar();

                if (Clientes is null)
                {
                    return NotFound("Nenhum Registro Encontrado");
                }

                return Ok(Clientes);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<ActionResult<Cliente>> SelecionarId(int id)
        {
            try
            {
                var cliente = await _clienteRepository.SelecionarId(id);

                if (cliente is null)
                {
                    return NotFound("Registro não Encontrado");
                }

                return Ok(cliente);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest("Dados Invalido");

            await _clienteRepository.Cadastrar(cliente);

            return new CreatedAtRouteResult("GetCliente",
                new { id = cliente.Id }, cliente);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> Put(int id,Cliente cliente)
        {
            if (cliente == null)
                return BadRequest("Dados invalidos");

            if (id != cliente.Id)
            {
                return BadRequest("Cliente invalido");
            }

            await _clienteRepository.Alterar(id,cliente);

            return Ok(cliente);
        }

    }
}
