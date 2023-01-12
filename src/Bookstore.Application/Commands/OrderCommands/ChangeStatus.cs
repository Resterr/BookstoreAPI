﻿using Bookstore.Shared.Abstractions.Commands;
using Bookstore.Shared.Consts;

namespace Bookstore.Application.Commands.OrderCommands;
public record ChangeStatus(long Id, OrderStatus orderStatus) : ICommand;
