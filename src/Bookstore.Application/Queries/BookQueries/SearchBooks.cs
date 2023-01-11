﻿using Bookstore.Application.DTO;
using Bookstore.Shared.Abstractions.Queries;

namespace Bookstore.Application.Queries.BookQueries;
public class SearchBooks : IQuery<IPagedResult<BookDto>>
{
	public int PageNumber { get; set; }
	public int PageSize { get; set; }
	public string SearchPhrase { get; set; }
}
