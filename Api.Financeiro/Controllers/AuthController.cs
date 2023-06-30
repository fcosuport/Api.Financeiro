using Api.Financeiro.Data;
using Api.Financeiro.Models;
using Api.Financeiro.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Financeiro.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public AuthController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Auth([FromBody] Usuario usuario)
        {
            // Verificar se o usuário e a senha são válidos no banco de dados
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Nome == usuario.Nome && u.Senha == usuario.Senha);
            if (user != null)
            {
                // Gere o token para o usuário válido
                var token = TokenService.GenerateToken(user);

                // Retorne o usuário sem a senha e o token
                return Ok(new { user = new { id = user.Id, nome = user.Nome }, token = token });
            }

            return BadRequest(new { mensagem = "nome ou senha inválida" });
        }
    }
}
