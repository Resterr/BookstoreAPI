using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Bookstore.Application.Functions.Orders.Commands.ChangeStatus;
public class ChangeStatusValidator : AbstractValidator<ChangeStatus>
{
	private readonly string[] _allowedStatusNames = new[] { "Pending", "Accepted", "Canceled", "Returned" };

	public ChangeStatusValidator()
	{
		RuleFor(r => r.StatusName).Custom((value, context) =>
		{
			if (!_allowedStatusNames.Contains(value))
			{
				context.AddFailure("StatusName", $"StatusName must in [{string.Join(",", _allowedStatusNames)}]");
			}
		});
	}
}
