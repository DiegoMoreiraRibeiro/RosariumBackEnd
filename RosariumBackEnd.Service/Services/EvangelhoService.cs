using RosariumBackEnd.Domain.Interfaces;
using RosariumBackEnd.Entities.Entities;
using RosariumBackEnd.Service.Interfaces;

namespace RosariumBackEnd.Service.Services
{
    public class EvangelhoService : IEvangelhoService
    {
        private readonly IEvangelhoRepository _evangelhoRepository;

        public EvangelhoService(IEvangelhoRepository evangelhoRepository)
        {
            _evangelhoRepository = evangelhoRepository;
        }

        public async Task<IQueryable<Evangelho>> GetAllEvangelhosAsync()
        {
            try
            {
                return await _evangelhoRepository.GetAllAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
