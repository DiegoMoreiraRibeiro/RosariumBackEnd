using RosariumBackEnd.Entities.Entities;

namespace RosariumBackEnd.Service.Interfaces
{


    public interface ILiturgiaService
    {
        Task<Liturgia> AddLiturgia(Liturgia liturgia);
    }
}
