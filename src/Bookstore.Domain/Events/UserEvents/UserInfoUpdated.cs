﻿using Bookstore.Domain.Entities;
using Bookstore.Shared.Abstractions.Domain;

namespace Bookstore.Domain.Events.UserEvents;
public record UserInfoUpdated(User user) : IDomainEvent;
