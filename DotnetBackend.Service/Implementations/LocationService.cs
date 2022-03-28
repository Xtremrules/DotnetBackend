using DotnetBackend.Core.DTO;
using DotnetBackend.Core.Entities;
using DotnetBackend.Data.Repositories;

namespace DotnetBackend.Service.Implementations
{
    public class LocationService: ILocationService
    {
        private readonly IRepository<State> stateRepo;
        private readonly IRepository<LGA> lgaRepo;

        public LocationService(IRepository<State> stateRepo, IRepository<LGA> lgaRepo)
        {
            this.stateRepo = stateRepo;
            this.lgaRepo = lgaRepo;
        }

        public IEnumerable<StateDTO> GetAllStates()
        {

            return stateRepo.GetAll().Select(x => new StateDTO
            {
                Id = x.Id,
                Name = x.Name
            });
        }

        public LGADTO GetLGAs(long stateId)
        {
            var lgas = lgaRepo.GetWhere(x => x.StateId == stateId).Result.Select(x => new lga { Id = x.Id, Name = x.Name });

            return new LGADTO { StateId = stateId, Lgas = lgas };
        }
    }
}
