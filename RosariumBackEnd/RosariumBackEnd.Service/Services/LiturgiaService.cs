using RosariumBackEnd.Domain.Interfaces;
using RosariumBackEnd.Entities.Entities;
using RosariumBackEnd.Service.Interfaces;

namespace RosariumBackEnd.Service.Services
{
    public class LiturgiaService : ILiturgiaService
    {
        private readonly ILiturgiaRepository _liturgiaRepository;

        public LiturgiaService(ILiturgiaRepository liturgiaRepository)
        {
            _liturgiaRepository = liturgiaRepository;
        }

        public async Task<Liturgia> AddLiturgia(Liturgia liturgia)
        {
            try
            {
                return await _liturgiaRepository.CreateAsync(liturgia);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
