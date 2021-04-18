using Core.Entities.Identity;

namespace Core.Entities
{
    public class UserGame : BaseEntity
    {
        public int GameId { get; set; }
        public string AppUserId { get; set; }

        public virtual Game Game { get; set; }
        public virtual AppUser User { get; set; }
    }
}
