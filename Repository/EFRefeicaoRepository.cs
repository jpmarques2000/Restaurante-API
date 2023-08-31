using RestauranteAPI.Entity;
using RestauranteAPI.Interface;

namespace RestauranteAPI.Repository
{
    public class EFRefeicaoRepository : EFRepository<Usuario>, IRefeicaoRepository
    {
        public EFRefeicaoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void AddNew(Refeicao entidade)
        {
            throw new NotImplementedException();
        }

        public Refeicao GetOrders(int it)
        {
            throw new NotImplementedException();
        }

        public void Update(Refeicao entidade)
        {
            throw new NotImplementedException();
        }

        IList<Refeicao> IRepository<Refeicao>.GetAll()
        {
            throw new NotImplementedException();
        }

        Refeicao IRepository<Refeicao>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
