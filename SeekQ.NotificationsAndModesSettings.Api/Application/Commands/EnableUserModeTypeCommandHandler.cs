using App.Common.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SeekQ.NotificationsAndModesSettings.Api.Domain.ModesAggregate;
using SeekQ.NotificationsAndModesSettings.Api.Domain.NotificationsAggregate;
using SeekQ.NotificationsAndModesSettings.Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SeekQ.NotificationsAndModesSettings.Api.Application.Commands
{
    public class EnableUserModeTypeCommandHandler
    {
        public class Command : IRequest<UserModeType>
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

        public class Handler : IRequestHandler<Command, UserModeType>
        {
            private NotificationsModesSettingsDbContext _notificationsModesSettingsDbContext;

            public Handler(NotificationsModesSettingsDbContext notificationsModesSettingsDbContext)
            {
                _notificationsModesSettingsDbContext = notificationsModesSettingsDbContext;
            }

            public async Task<UserModeType> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                Guid id = request.Id;
                bool active = request.Active;

                UserModeType existingUserModeType = await _notificationsModesSettingsDbContext
                                                .UserModeTypes
                                                // .AsNoTracking()
                                                .SingleOrDefaultAsync(unt => unt.Id == id);

                if (existingUserModeType != null)
                {
                    existingUserModeType.Active = true;
                    _notificationsModesSettingsDbContext.UserModeTypes.Update(existingUserModeType);
                    int count = await _notificationsModesSettingsDbContext.SaveChangesAsync();
                    return existingUserModeType;
                }
                else
                {
                    throw new AppException($"The user notification type Id {id} already as not been found");
                }
            }
        }
    }
}
