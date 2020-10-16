using App.Common.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeekQ.NotificationsAndModesSettings.Api.Domain.NotificationsAggregate;
using SeekQ.NotificationsAndModesSettings.Api.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SeekQ.NotificationsAndModesSettings.Api.Application.Commands
{
    public class DisableUserNotificationTypeCommandHandler
    {
        public class Command : IRequest<UserNotificationType>
        {
            public Command(Guid id, bool active)
            {
                Id = id;
                Active = active;
            }
            public Guid Id { get; set; }
            public bool Active { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Id)
                    .NotNull().NotEmpty().WithMessage("The user notification Id is required");

                RuleFor(x => x.Active)
                    .NotNull().NotEmpty().WithMessage("The active is required");
            }
        }

        public class Handler : IRequestHandler<Command, UserNotificationType>
        {

            private NotificationsModesSettingsDbContext _notificationsModesSettingsDbContext;

            public Handler(NotificationsModesSettingsDbContext notificationsModesSettingsDbContext)
            {
                _notificationsModesSettingsDbContext = notificationsModesSettingsDbContext;
            }

            public async Task<UserNotificationType> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                Guid id = request.Id;
                bool active = request.Active;

                UserNotificationType existingUserNotificationType = await _notificationsModesSettingsDbContext
                                                .UserNotificationTypes
                                                // .AsNoTracking()
                                                .SingleOrDefaultAsync(unt => unt.Id == id);

                if (existingUserNotificationType != null)
                {
                    existingUserNotificationType.Active = false;
                    _notificationsModesSettingsDbContext.UserNotificationTypes.Update(existingUserNotificationType);
                    int count = await _notificationsModesSettingsDbContext.SaveChangesAsync();
                    return existingUserNotificationType;
                }
                else
                {
                    throw new AppException($"The user notification type Id {id} already as not been found");
                }
            }
        }
    }
}
