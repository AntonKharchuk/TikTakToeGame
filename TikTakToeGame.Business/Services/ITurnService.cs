
using TikTakToeGame.Entities;

namespace TikTakToeGame.Business.Services
{
    public interface ITurnService
    {
        Task<Turn> GetItemByIdAsync(int id);
    }
}
