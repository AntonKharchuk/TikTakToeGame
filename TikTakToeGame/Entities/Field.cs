
namespace TikTakToeGame.Entities
{
    public class Field: BaseEntity
    {
        public List<Mark>? Positions { get; set; }
        /*
        0,1,2
        3,4,5
        6,7,8
         */

        public int StatusId { get; set; }
        public Status? Status { get; set; }

        public int TurnId { get; set; }
        public Turn? Turn { get; set; }

    }

}
