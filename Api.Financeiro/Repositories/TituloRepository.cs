using Api.Financeiro.Data;
using Api.Financeiro.Interfaces;
using Api.Financeiro.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Api.Financeiro.Repositories
{
    public class TituloRepository : ITituloRepository
    {
        private readonly DataBaseContext _context;

        public TituloRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TituloDto>> Selecionar(int cliente, int formapagamento, int numparcela, string status, string opcaodata, DateTime datainicial, DateTime datafinal, string ordenar)
        {
            IQueryable<Titulo> query = _context.Titulos
                 .Include(t => t.Cliente)
                 .Include(t => t.FormaPagamento)
                 .Where(t => t.Cancelado == false);

            if (cliente > 0)
            {
                query = query.Where(t => t.ClienteId == cliente);
            }

            if (formapagamento > 0)
                query = query.Where(t => t.FormaPagamentoId == formapagamento);

            if (numparcela > 0)
                query = query.Where(t => t.NumParcela == numparcela);

            if (status != "Todos")
            {
                query = query.Where(t => t.Status == status);
            }

            if (opcaodata == "Emissao")
            {
                query = query.Where(t => t.Emissao >= datainicial && t.Emissao <= datafinal);
            }

            if (opcaodata == "Vencimento")
            {
                query = query.Where(t => t.Vencimento >= datainicial && t.Vencimento <= datafinal);
            }

            if (opcaodata == "DtPagamento")
            {
                query = query.Where(t => t.DtPagamento >= datainicial && t.DtPagamento <= datafinal);
            }

            switch (ordenar)
            {
                case "emissao":
                    query = query.OrderBy(t => t.Emissao);
                    break;
                case "vencimento":
                    query = query.OrderBy(t => t.Vencimento);
                    break;
                case "cliente":
                    query = query.OrderBy(t => t.Cliente.Razao).ThenBy(t => t.Vencimento);
                    break;
                default:
                    // Caso não seja fornecido um campo de ordenação válido, não aplicar a ordenação
                    break;
            }


            var result = await query
           .Select(t => new TituloDto
           {
               Id = t.Id,
               ClienteRazao = t.Cliente.Razao,
               FormaPagamentoDescricao = t.FormaPagamento.Descricao,
               Valor = t.Valor,
               Status = t.Status,
               NumParcela = t.NumParcela,
               Emissao = t.Emissao,
               Vencimento = t.Vencimento,
               DtPagamento = t.DtPagamento
           })
            .ToListAsync();

            return result;
        }

        public async Task<Titulo> SelecionarId(int id)
        {
            return await _context.Titulos.Where(t => t.Id == id).FirstOrDefaultAsync();
        }


        public async Task<Titulo> Cadastrar(Titulo titulo)
        {
            var datavenc = titulo.Vencimento;
            var dia = titulo.Vencimento.Day;

            for (int i = 1; i <= titulo.QtdeParcelas; i++)
            {
                var novotitulo = new Titulo
                {
                    ClienteId = titulo.ClienteId,
                    FormaPagamentoId = titulo.FormaPagamentoId,
                    Valor = titulo.Valor,
                    Status = titulo.Status,
                    QtdeParcelas = titulo.QtdeParcelas,
                    Emissao = titulo.Emissao,
                    Vencimento = datavenc,
                    NumParcela = i,
                    Cancelado = false
                };

                _context.Titulos.Add(novotitulo);

                if (i >= 1)
                {
                    datavenc = datavenc.AddMonths(1);
                    datavenc = new DateTime(datavenc.Year, datavenc.Month, dia);

                    //datavenc = datavenc.AddDays(30);
                }
                                
            }

            await _context.SaveChangesAsync();

            return titulo;
        }


        public async Task<Titulo> Alterar(int id, Titulo titulo)
        {
            _context.Entry(titulo).State = EntityState.Modified;
            _context.Entry(titulo).Property(t => t.DtPagamento).IsModified = false;
            _context.Entry(titulo).Property(t => t.Cancelado).IsModified = false;

            await _context.SaveChangesAsync();
            return titulo;
        }

        public async Task<Titulo> Cancelar(int id)
        {
            Titulo titulo = new Titulo();
            titulo = await SelecionarId(id);
            titulo.Cancelado = true;
            await _context.SaveChangesAsync();
            return titulo;
        }

    }
}
