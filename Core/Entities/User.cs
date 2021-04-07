using System.Collections.Generic;

namespace Core.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }

        public virtual IReadOnlyCollection<Session> Sessions { get; set; }
        public virtual IReadOnlyCollection<UserGame> UserGames { get; set; }
    }
}
