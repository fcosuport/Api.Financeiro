using Api.Financeiro.Data;
using Api.Financeiro.Interfaces;
using Api.Financeiro.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Financeiro.Repositories
{
    public class AssinaturaRepository : IAssinaturaRepository
    {
        private readonly DataBaseContext _context;

        public AssinaturaRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AssinaturaDto>> Selecionar(string cliente, int produto, int plano, int formapagamento, string status)
        {
            IQueryable<Assinatura> query = _context.Assinaturas
                .Include(a => a.Cliente)
                .Include(a => a.Produto)
                .Include(a => a.Plano)
                .Include(a => a.FormaPagamento);

            if (!string.IsNullOrEmpty(cliente))
            {
                // query = query.Where(a => a.Cliente.Razao.Contains(cliente));
                query = query.Where(a => a.Cliente.Razao.ToLower().Contains(cliente.ToLower()));
            }

            if (produto > 0)
                query = query.Where(a => a.ProdutoId == produto);

            if (plano > 0)
                query = query.Where(a => a.PlanoId == plano);

            if (formapagamento > 0)
                query = query.Where(a => a.FormaPagamentoId == formapagamento);

            if (status != "Todos")
            {
                if (status == "Inativa")
                {
                    query = query.Where(a => a.Cancelado == true);
                }
                else
                {
                    query = query.Where(a => a.Cancelado == false);
                }
            }


            var result = await query
           .Select(a => new AssinaturaDto
            {
                Id = a.Id,
                ClienteRazao = a.Cliente.Razao,
                ClienteTelefone = a.Cliente.Telefone,
                ProdutoDescricao = a.Produto.Descricao,
                PlanoDescricao = a.Plano.Descricao,
                FormaPagamentoDescricao = a.FormaPagamento.Descricao,
                DiaVencimento = a.DiaVencimento,
                Valor = a.Valor,
                Dtcadastro = a.Dtcadastro,
                Dtcancelamento = a.Dtcancelamento,
                Cancelado = a.Cancelado
            })
            .ToListAsync();

            return result;

            /*
            var result = await _context.Assinaturas
                .Include(a => a.Cliente)
                .Include(a => a.Produto)
                .Include(a => a.Plano)
                .Include(a => a.FormaPagamento)
                .Select(a => new AssinaturaDto
                {
                    Id = a.Id,
                    ClienteRazao = a.Cliente.Razao,
                    ClienteTelefone = a.Cliente.Telefone,
                    ProdutoDescricao = a.Produto.Descricao,
                    PlanoDescricao = a.Plano.Descricao,
                    FormaPagamentoDescricao = a.FormaPagamento.Descricao,
                    DiaVencimento = a.DiaVencimento,
                    Valor = a.Valor,
                    Dtcadastro = a.Dtcadastro,
                    Dtcancelamento = a.Dtcancelamento,
                    Cancelado = a.Cancelado
                })
                .ToListAsync();

            return result;        
            */
        }

        public async Task<Assinatura> SelecionarId(int id)
        {
            return await _context.Assinaturas.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Assinatura> Cadastrar(Assinatura assinatura)
        {
            assinatura.Cancelado = false;

            _context.Assinaturas.Add(assinatura);
            await _context.SaveChangesAsync();
            return assinatura;
        }

        public async Task<Assinatura> Alterar(int id, Assinatura assinatura)
        {
            _context.Entry(assinatura).State = EntityState.Modified;
            _context.Entry(assinatura).Property(a => a.Dtcancelamento).IsModified = false;
            _context.Entry(assinatura).Property(a => a.Cancelado).IsModified = false;
            _context.Entry(assinatura).Property(a => a.Dtcadastro).IsModified = false;
            await _context.SaveChangesAsync();
            return assinatura;
        }

        public async Task<Assinatura> Cancelar(int id)
        {
            Assinatura assinatura = new Assinatura();
            assinatura = await SelecionarId(id);
            assinatura.Cancelado = true;
            assinatura.Dtcancelamento = DateTime.Now;
            await _context.SaveChangesAsync();
            return assinatura;

        }

    }
}
