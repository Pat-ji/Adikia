using System.Collections.Generic;

namespace Core.Entities
{
    public class GameDialogue : BaseEntity
    {
        public int GameId { get; set; }
        public int DialogueId { get; set; }
        public int GameStage { get; set; }

        public virtual Game Game { get; set; }
        public virtual Dialogue Dialogue { get; set; }

        public virtual IReadOnlyCollection<GameDialogueAction> GameDialogueActions { get; set; }
    }
}
