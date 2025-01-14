using FirstProject.Core.Entities;
using FirstProject.DAL.Contexts;
using FirstProject.DAL.Repositories.Abstractions;

namespace FirstProject.DAL.Repositories.Implementations
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(AppDbContext context) : base(context)
        {
        }
    }
}
