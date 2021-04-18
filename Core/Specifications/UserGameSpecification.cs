using Core.Entities;
using Core.Entities.Identity;

namespace Core.Specifications
{
    public static class UserGameSpecification
    {
        public class BaseUserGameSpecification : BaseSpecification<UserGame>
        {
            public BaseUserGameSpecification(AppUser user) : base(x => x.AppUserId.Equals(user.Id))
            {
            }
        }

        public class Pagination : BaseUserGameSpecification
        {
            public Pagination(AppUser user, int pageIndex, int pageSize) : base(user)
            {
                ApplyPaging(pageSize * (pageIndex - 1), pageSize);

                AddInclude(x => x.Game);
            }
        }

        public class UserHasGame : BaseUserGameSpecification
        {
            public UserHasGame(AppUser user, int gameId) : base(user)
            {
                AddCriteria(x => x.GameId == gameId);
            }
        }
    }
}
