
using TikTakToeGame.Entities;
using TikTakToeGame.Repositories;

namespace TikTakToeGame.Business.Services
{
    public class TurnService : ITurnService
    {
        private IGenericRepository<Turn> _genericRepository;

        public TurnService(IGenericRepository<Turn> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<Turn> GetItemByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }
    }
}
