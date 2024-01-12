
using TikTakToeGame.Entities;

namespace TikTakToeGame.Business.Services
{
    public interface IFieldService
    {
        Task<IEnumerable<Field>> GetAllItemsAsync();
        Task<Field> GetItemByIdAsync(int id);
        Task CreateItemAsync();
        Task UpdateItemAsync(List<int> positions, int id);
    }
}
