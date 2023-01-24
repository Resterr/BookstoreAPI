﻿using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Infrastructure.EF.Queries;
internal class PagedResult<T> : IPagedResult<T> where T : class
{
	public List<T> Items { get; set; }
	public int TotalPages { get; set; }
	public int ItemsFrom { get; set; }
	public int ItemsTo { get; set; }
	public int TotalItemsCount { get; set; }

	public PagedResult(List<T> items, int totalCount, int pageSize, int pageNumber)
	{
		Items = items;
		TotalItemsCount = totalCount;
		ItemsFrom = pageSize * (pageNumber - 1) + 1;
		ItemsTo = ItemsFrom + pageSize - 1;
		TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
	}
}
