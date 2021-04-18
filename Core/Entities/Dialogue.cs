using System.Collections.Generic;

namespace Core.Entities
{
    public class Dialogue : BaseEntity
    {
        public string Messages { get; set; }

        public virtual IReadOnlyCollection<CharacterDialogue> CharacterDialogues { get; set; }
        public virtual IReadOnlyCollection<GameDialogue> GameDialogues { get; set; }
    }
}
