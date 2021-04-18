using System.Collections.Generic;

namespace Core.Entities
{
    public class Evidence : Resource
    {
        public virtual IReadOnlyCollection<UnlockableEvidence> UnlockableEvidence { get; set; }
        public virtual IReadOnlyCollection<SessionEvidence> SessionEvidence { get; set; }
    }
}
