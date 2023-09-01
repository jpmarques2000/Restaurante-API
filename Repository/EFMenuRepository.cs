using RestauranteAPI.Interface;
using RestauranteAPI.Models;

namespace RestauranteAPI.Repository
{
    public class EFMenuRepository : EFRepository<Menu>, IMenuRepository
    {
        public EFMenuRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
