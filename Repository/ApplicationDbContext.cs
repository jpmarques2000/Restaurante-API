using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Models;

namespace RestauranteAPI.Repository
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Meal> Refeicao { get; set; }
        public DbSet<User> Usuario { get; set; }
        public DbSet<Order> Pedido { get; set; }
        public DbSet<Menu> Cardapio { get; set; }
        public DbSet<MenuMeal> MenuMeal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                _configuration.GetValue<string>("ConnectionStrings:ConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.Entity<Meal>().HasData(
                new Meal { Id = 100000, Nome = "Refeicaoteste1",
                    Descricao = "Uma refeição teste ai", Preco = 30 },
                new Meal { Id = 100001, Nome = "Refeicaoteste2",
                    Descricao = "Outra refeição teste ai", Preco = 20 },
                new Meal { Id = 100002, Nome = "Refeicaoteste3",
                    Descricao = "Mais uma refeição teste ai", Preco = 50 }
            );
        }
    }
}
