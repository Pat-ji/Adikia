using System.Collections.Generic;

namespace Core.Entities
{
    public class Game : Resource
    {
        public int CompletedGameStage { get; set; }

        public virtual IReadOnlyCollection<Hint> Hints { get; set; }
        public virtual IReadOnlyCollection<UnlockableEvidence> UnlockableEvidence { get; set; }
        public virtual IReadOnlyCollection<UserGame> UserGames { get; set; }
        public virtual IReadOnlyCollection<Character> Characters { get; set; }
        public virtual IReadOnlyCollection<GameDialogue> GameDialogues { get; set; }
        public virtual IReadOnlyCollection<Session> Sessions { get; set; }
    }
}
