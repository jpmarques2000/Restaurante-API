using RestauranteAPI.Entity;
using RestauranteAPI.Interface;

namespace RestauranteAPI.Repository
{
    public class EFRefeicaoRepository : EFRepository<Refeicao>, IRefeicaoRepository
    {
        public EFRefeicaoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Refeicao GetOrders(int id)
        {
            throw new NotImplementedException();
        }
    }
}
