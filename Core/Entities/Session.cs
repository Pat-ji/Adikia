using Core.Entities.Identity;
using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Session : BaseEntity
    {
        public string AppUserId { get; set; }
        public int GameId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int GameStage { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual Game Game { get; set; }

        public virtual IReadOnlyCollection<SessionCharacter> SessionCharacters { get; set; }
        public virtual IReadOnlyCollection<SessionEvidence> SessionEvidence { get; set; }
    }
}
