using RestauranteAPI.Entity;
using RestauranteAPI.Interface;

namespace RestauranteAPI.Repository
{
    public class EFCardapioRepository : EFRepository<Cardapio>, ICardapioRepository
    {
        public EFCardapioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
