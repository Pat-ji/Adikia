using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data
{
	public class Pagination<T> : IPagination<T> where T : class
	{
		public int PageIndex { get; private set; }
		public int PageSize { get; private set; }
		public int Count { get; private set; }
		public IReadOnlyList<T> Data { get; private set; }

		public Pagination(int pageIndex, int pageSize, int count, IReadOnlyList<T> data)
		{
			PageIndex = pageIndex;
			PageSize = pageSize;
			Count = count;
			Data = data;
		}
	}

	public static class Extension
	{
		public static IPagination<T2> Mapped<T1, T2>(this IPagination<T1> pagination, Func<T1, T2> map) where T1 : class where T2 : class
		{
			return new Pagination<T2>(pagination.PageIndex, pagination.PageSize, pagination.Count, pagination.Data.Select(x => map(x)).ToList());
		}
	}
}
