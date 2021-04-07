using System.Collections.Generic;

namespace Core.Entities
{
    public class Game : BaseEntity
    {
        public string Name { get; set; }

        public virtual IReadOnlyCollection<UserGame> UserGames { get; set; }
    }
}
