using Api.Financeiro.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Financeiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OthersController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public OthersController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet("assinaturaswhats/{dia}")]
        public async Task<ActionResult> BuscarAssinaturas(int dia)
        {
            var assinaturas = await _context.Assinaturas
                .Where(a => !a.Cancelado && a.DiaVencimento == dia && !string.IsNullOrEmpty(a.CodAssinatura))
                .Select(a => new { a.CodAssinatura, a.NomeWhats })
                .ToListAsync();

            return Ok(assinaturas);
        }

    }
}
