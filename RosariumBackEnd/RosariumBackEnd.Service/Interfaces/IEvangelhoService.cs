using RosariumBackEnd.Entities.Entities;

namespace RosariumBackEnd.Service.Interfaces
{
    public interface IEvangelhoService
    {
        Task<IQueryable<Evangelho>> GetAllEvangelhosAsync();
    }
}
