using System.Collections.Generic;

namespace Core.Entities
{
    public class CharacterDialogue : BaseEntity
    {
        public int CharacterId { get; set; }
        public int DialogueId { get; set; }
        public int CharacterStage { get; set; }

        public virtual Character Character { get; set; }
        public virtual Dialogue Dialogue { get; set; }

        public virtual IReadOnlyCollection<CharacterDialogueAction> CharacterDialogueActions { get; set; }
    }
}
