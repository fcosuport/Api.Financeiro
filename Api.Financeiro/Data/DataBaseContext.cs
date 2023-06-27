using Api.Financeiro.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Financeiro.Data;

public class DataBaseContext: DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }

    public DbSet<Produto> Produtos { get; set; }

    public DbSet<Plano> Planos { get; set; }

    public DbSet<FormaPagamento> Formapagamentos { get; set; }

    public DbSet<Assinatura> Assinaturas { get; set; }

    public DbSet<Titulo> Titulos { get; set; }
}
