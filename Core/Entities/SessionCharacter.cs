namespace Core.Entities
{
    public class SessionCharacter : BaseEntity
    {
        public int SessionId { get; set; }
        public int CharacterId { get; set; }
        public int CharacterStage { get; set; }

        public virtual Session Session { get; set; }
        public virtual Character Character { get; set; }
    }
}
