
using TikTakToeGame.Entities;

namespace TikTakToeGame.Business.Services
{
    public interface IStatusService
    {
        Task<Status> GetItemByIdAsync(int id);
    }
}
