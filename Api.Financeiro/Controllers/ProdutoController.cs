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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Listar()
        {
            try
            {
                var Produtos = await _produtoRepository.Listar();

                if (Produtos is null)
                {
                    return NotFound("Nenhum Registro Encontrado");
                }

                return Ok(Produtos);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}", Name = "GetProduto")]
        public async Task<ActionResult<Produto>> SelecionarId(int id)
        {
            try
            {
                var produto = await _produtoRepository.SelecionarId(id);

                if (produto is null)
                {
                    return NotFound("Registro não Encontrado");
                }

                return Ok(produto);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao acessar a base de dados");
            }
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Produto produto)
        {
            if (produto == null)
                return BadRequest("Dados Invalido");

            await _produtoRepository.Cadastrar(produto);

            return new CreatedAtRouteResult("GetProduto",
                new { id = produto.Id }, produto);
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> Put([FromBody] Produto produto)
        {
            if (produto == null)
                return BadRequest("Dados invalidos");

            await _produtoRepository.Alterar(produto);

            return Ok(produto);
        }

    }
}
