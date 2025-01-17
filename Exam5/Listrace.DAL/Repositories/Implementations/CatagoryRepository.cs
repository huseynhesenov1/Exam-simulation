using Listrace.Core.Entities;
using Listrace.DAL.Contexts;
using Listrace.DAL.Repositories.Abstractions;

namespace Listrace.DAL.Repositories.Implementations
{
	public class CatagoryRepository : GenericRepository<Catagory>, ICatagoryRepository
	{
		public CatagoryRepository(AppDbContext context) : base(context)
		{

		}
	}
}
