using System.Collections.Generic;

namespace Core.Entities
{
    public class Character : Resource
    {
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public virtual IReadOnlyCollection<CharacterDialogue> CharacterDialogues { get; set; }
        public virtual IReadOnlyCollection<SessionCharacter> SessionCharacters { get; set; }
    }
}
