namespace Core.Entities
{
    public class Hint : BaseEntity
    {
        public int GameId { get; set; }
        public int GameStage { get; set; }
        public string Information { get; set; }

        public virtual Game Game { get; set; }
    }
}
