namespace Core.Entities
{
    public class UserGame
    {
        public int GameId { get; set; }
        public int UserId { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
