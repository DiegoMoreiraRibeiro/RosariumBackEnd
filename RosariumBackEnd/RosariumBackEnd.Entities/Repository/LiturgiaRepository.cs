using RosariumBackEnd.Domain.Interfaces;
using RosariumBackEnd.Entities.Entities;

namespace RosariumBackEnd.Domain.Repository
{
    public class LiturgiaRepository : BaseRepository<Liturgia>, ILiturgiaRepository
    {
        private readonly MyApplicationDbContext _context;

        public LiturgiaRepository(MyApplicationDbContext context) : base(context)
        {
        }


    }
}
