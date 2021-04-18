namespace Core.Entities
{
    public class SessionEvidence : BaseEntity
    {
        public int SessionId { get; set; }
        public int EvidenceId { get; set; }

        public virtual Session Session { get; set; }
        public virtual Evidence Evidence { get; set; }
    }
}
