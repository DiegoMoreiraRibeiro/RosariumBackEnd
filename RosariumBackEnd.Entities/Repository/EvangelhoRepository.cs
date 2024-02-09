using RosariumBackEnd.Domain.Interfaces;
using RosariumBackEnd.Entities.Entities;

namespace RosariumBackEnd.Domain.Repository
{
    public class EvangelhoRepository : BaseRepository<Evangelho>, IEvangelhoRepository
    {
        private readonly MyApplicationDbContext _context;

        public EvangelhoRepository(MyApplicationDbContext context) : base(context)
        {
        }


    }
}
