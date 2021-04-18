namespace Core.Entities
{
    public class CharacterDialogueAction : BaseEntity
    {
        public int CharacterDialogueId { get; set; }
        public string TriggerWord { get; set; }
        public int? NextCharacterStage { get; set; }
        public int? NextGameStage { get; set; }

        public virtual CharacterDialogue CharacterDialogue { get; set; }
    }
}
