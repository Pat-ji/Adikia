using Core.Entities;
using Core.Entities.Identity;

namespace Core.Specifications
{
    public static class SessionSpecification
    {
        public class BaseSessionSpecification : BaseSpecification<Session>
        {
            public BaseSessionSpecification(AppUser user) : base(x => x.AppUserId.Equals(user.Id))
            {
            }
        }

        public class Pagination : BaseSessionSpecification
        {
            public Pagination(AppUser user, int pageIndex, int pageSize) : base(user)
            {
                ApplyPaging(pageSize * (pageIndex - 1), pageSize);

                AddInclude(x => x.Game);
            }
        }
    }
}
