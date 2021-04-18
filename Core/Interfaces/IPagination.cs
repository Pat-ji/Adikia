using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IPagination<T> where T : class
    {
        public int PageIndex { get; }
        public int PageSize { get; }
        public int Count { get; }
        public IReadOnlyList<T> Data { get; }
    }
}
