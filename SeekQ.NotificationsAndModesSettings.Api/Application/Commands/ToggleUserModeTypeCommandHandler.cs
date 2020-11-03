using App.Common.Exceptions;
using FluentValidation;
using MediatR;
using SeekQ.NotificationsAndModesSettings.Api.Domain.ModesAggregate;
using SeekQ.NotificationsAndModesSettings.Api.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SeekQ.NotificationsAndModesSettings.Api.Application.Commands
{
    public class ToggleUserModeTypeCommandHandler
    {
        public class Command : IRequest<bool>
        {
            public Guid Id { get; set; }
            public bool Active { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Id)
                    .NotNull().NotEmpty().WithMessage("The user mode Id is required");

                RuleFor(x => x.Active)
                    .NotNull().Must(x => x == false || x == true).WithMessage("The user mode active is required");
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
                bool active = request.Active;

                UserModeType existingUserNotificationType = _notificationsModesSettingsDbContext.UserModeTypes.Find(id);

                if (existingUserNotificationType != null)
                {
                    existingUserNotificationType.Active = active;
                    _notificationsModesSettingsDbContext.UserModeTypes.Update(existingUserNotificationType);
                    return await _notificationsModesSettingsDbContext.SaveChangesAsync() > 0;
                }
                else
                {
                    throw new AppException($"The user mode type Id {id} already as not been found");
                }
            }
        }
    }
}
