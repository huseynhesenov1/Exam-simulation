using Project.Core.Entities;
using Project.DAL.Contexs;
using Project.DAL.Repositories.Abstractions;

namespace Project.DAL.Repositories.Implementations
{
    public class NewsRepository : GenericRepository<News>, INewsRepository
    {
        public NewsRepository(AppDbContext context) : base(context)
        {
        }
    }
}
