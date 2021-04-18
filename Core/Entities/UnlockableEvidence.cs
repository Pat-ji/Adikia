namespace Core.Entities
{
    public class UnlockableEvidence : BaseEntity
    {
        public int GameId { get; set; }
        public int EvidenceId { get; set; }
        public int GameStage { get; set; }

        public virtual Game Game { get; set; }
        public virtual Evidence Evidence { get; set; }
    }
}
