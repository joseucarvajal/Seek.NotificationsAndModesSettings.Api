using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeekQ.NotificationsAndModesSettings.Api.Application.Commands;
using SeekQ.NotificationsAndModesSettings.Api.Application.Queries;
using SeekQ.NotificationsAndModesSettings.Api.Domain.ModesAggregate;
using SeekQ.NotificationsAndModesSettings.Api.Domain.NotificationsAggregate;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SeekQ.NotificationsAndModesSettings.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]            
    public class NotificationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public NotificationsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet()]
        [Route("notifications/user/{idUser}")]
        [SwaggerOperation(Summary = "Get notifications settings by user")]
        public async Task<IEnumerable<GetNotificationsByUserViewModel>> GetNotificationsByUser(
            [FromRoute] Guid idUser
        )
        {
            return await _mediator.Send(new GetNotificationsByUserQueryHandler.Query(idUser));
        }

        [HttpGet()]
        [Route("modes/user/{idUser}")]
        [SwaggerOperation(Summary = "Get modes settings by user")]
        public async Task<IEnumerable<GetModesByUserViewModel>> GetModesByUser(
            [FromRoute] Guid idUser
        )
        {
            return await _mediator.Send(new GetModesByUserQueryHandler.Query(idUser));
        }

        [HttpPost]
        [Route("notifications/user/enable")]
        [SwaggerOperation(Summary = "Enable user notification setting")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Notification user enabled succesfully")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad Request")]
        public async Task<ActionResult<UserNotificationType>> EnableUserNotificationType(
            [FromBody] EnableUserNotificationTypeCommandHandler.Command userNotificationType
        )
        {
            return await _mediator.Send(userNotificationType);
        }

        [HttpPost]
        [Route("notifications/user/disable")]
        [SwaggerOperation(Summary = "Disable account notification/mode setting")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Account notification/mode setting Disabled succesfully")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad Request")]
        public async Task<ActionResult<UserNotificationType>> DisableUserNotificationType(
            [FromBody] DisableUserNotificationTypeCommandHandler.Command userNotificationType
        )
        {
            return await _mediator.Send(userNotificationType);
        }

        [HttpPost]
        [Route("notifications/user/enable")]
        [SwaggerOperation(Summary = "Enable user notification setting")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Notification user enabled succesfully")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad Request")]
        public async Task<ActionResult<UserModeType>> EnableUserModeType(
            [FromBody] EnableUserModeTypeCommandHandler.Command userModeType
        )
        {
            return await _mediator.Send(userModeType);
        }

        [HttpPost]
        [Route("notifications/user/disable")]
        [SwaggerOperation(Summary = "Disable account notification/mode setting")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Account notification/mode setting Disabled succesfully")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad Request")]
        public async Task<ActionResult<UserModeType>> DisableUserModeType(
            [FromBody] DisableUserModeTypeCommandHandler.Command userModeType
        )
        {
            return await _mediator.Send(userModeType);
        }
    }
}
