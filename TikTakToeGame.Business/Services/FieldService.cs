using TikTakToeGame.Entities;
using TikTakToeGame.Repositories;

namespace TikTakToeGame.Business.Services
{
    public class FieldService : IFieldService
    {
        private IGenericRepository<Field> _genericRepository;

        public FieldService(IGenericRepository<Field> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task CreateItemAsync()
        {
            var newField = new Field()
            {
                StatusId = 1,
                TurnId = 1,
            };
            await _genericRepository.AddAsync(newField);
            await _genericRepository.SaveAsync();   
        }

        public async Task<IEnumerable<Field>> GetAllItemsAsync()
        {
            return await _genericRepository.GetAllAsync();
        }

        public async Task<Field> GetItemByIdAsync(int id)
        {
            return await _genericRepository.GetByIdAsync(id);
        }

        public async Task UpdateItemAsync(string positions, int id)
        {
            if (positions.Length!=9)
            {
                throw new ArgumentException();
            }
            var tableItem =  await _genericRepository.GetByIdAsync(id);

            tableItem.Positions = positions;

            await _genericRepository.SaveAsync();
        }
    }
}
