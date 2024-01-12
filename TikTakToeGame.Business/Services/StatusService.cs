
using TikTakToeGame.Entities;
using TikTakToeGame.Repositories;

namespace TikTakToeGame.Business.Services
{
    public class StatusService : IStatusService
    {
        private IGenericRepository<Status> _genericRepository;

        public StatusService(IGenericRepository<Status> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<Status> GetItemByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }
    }
}
