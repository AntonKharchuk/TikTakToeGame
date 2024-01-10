
namespace TikTakToeGame.Entities
{
    public class Field: BaseEntity
    {
        public int[,] Positions { get; set; }//0 none, 1 X, 2 O
        public int StatusId { get; set; }
        public int TurnId { get; set; }
    }

}
