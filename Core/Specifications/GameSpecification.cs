using Core.Entities;

namespace Core.Specifications
{
    public static class GameSpecification
    {
        public class Pagination : BaseSpecification<Game>
        {
            public Pagination(int pageIndex, int pageSize)
            {
                ApplyPaging(pageSize * (pageIndex - 1), pageSize);
            }
        }

        public class WithCharacters : BaseSpecification<Game>
        {
            public WithCharacters(int id) : base(x => x.Id == id)
            {
                AddInclude(x => x.Characters);
            }
        }
    }
}
