using Listrace.Core.Entities;
using Listrace.DAL.Contexts;
using Listrace.DAL.Repositories.Abstractions;

namespace Listrace.DAL.Repositories.Implementations
{
	public class PlaceRepository : GenericRepository<Place>, IPlaceRepository
	{
		public PlaceRepository(AppDbContext context) : base(context)
		{
		}
	}
}
