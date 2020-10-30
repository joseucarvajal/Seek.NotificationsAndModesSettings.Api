﻿using App.Common.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeekQ.NotificationsAndModesSettings.Api.Domain.NotificationsAggregate;
using SeekQ.NotificationsAndModesSettings.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SeekQ.NotificationsAndModesSettings.Api.Application.Commands
{
    public class EnableUserNotificationTypeCommandHandler
    {
        public class Command : IRequest<bool>
        {
            public Guid Id { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Id)
                    .NotNull().NotEmpty().WithMessage("The user notification Id is required");
            }
        }

        public class Handler : IRequestHandler<Command, bool>
        {

            private NotificationsModesSettingsDbContext _notificationsModesSettingsDbContext;

            public Handler(NotificationsModesSettingsDbContext notificationsModesSettingsDbContext)
            {
                _notificationsModesSettingsDbContext = notificationsModesSettingsDbContext;
            }

            public async Task<bool> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                Guid id = request.Id;

                UserNotificationType existingUserNotificationType = _notificationsModesSettingsDbContext.UserNotificationTypes.Find(id);

                if (existingUserNotificationType != null)
                {
                    existingUserNotificationType.Active = true;
                    _notificationsModesSettingsDbContext.UserNotificationTypes.Update(existingUserNotificationType);
                    return await _notificationsModesSettingsDbContext.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new AppException($"The user notification type Id {id} already as not been found");
                }
            }
        }
    }
}
