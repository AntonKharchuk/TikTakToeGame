
namespace TikTakToeGame.Entities
{
    public class Field: BaseEntity
    {
        public int[,] Positions { get; set; }
        public int StatusId { get; set; }
        public int TurnId { get; set; }
    }

}
