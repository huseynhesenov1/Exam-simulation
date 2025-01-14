using Project.BL.Services.Abstractions;
using Project.Core.Entities;
using Project.DAL.Repositories.Abstractions;

namespace Project.BL.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _servicerepo;

        public ServiceService(IServiceRepository servicerepo)
        {
            _servicerepo = servicerepo;
        }

        public async Task<ICollection<Service>> GetAllAsync()
        {
             return await _servicerepo.GetAllAsync();
        }
    }
}
