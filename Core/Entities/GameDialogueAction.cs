namespace Core.Entities
{
    public class GameDialogueAction : BaseEntity
    {
        public int GameDialogueId { get; set; }
        public string Action { get; set; }
        public int NextGameStage { get; set; }

        public virtual GameDialogue GameDialogue { get; set; }
    }
}
