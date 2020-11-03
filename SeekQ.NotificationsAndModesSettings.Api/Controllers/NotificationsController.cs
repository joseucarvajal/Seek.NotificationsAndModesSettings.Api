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

        [HttpGet]
        [Route("user/{idUser}")]
        [SwaggerOperation(Summary = "Get notifications settings by user")]
        public async Task<IEnumerable<GetNotificationsByUserViewModel>> GetNotificationsByUser(
            [FromRoute] Guid idUser
        )
        {
            return await _mediator.Send(new GetNotificationsByUserQueryHandler.Query(idUser));
        }

        [HttpPost]
        [Route("user/toggle")]
        [SwaggerOperation(Summary = "Toggle user notification setting")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Notification user enabled succesfully")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad Request")]
        public async Task<bool> ToggleUserNotificationType(
            [FromBody]ToggleUserNotificationTypeCommandHandler.Command usernotificationtype
        )
        {
            return await _mediator.Send(usernotificationtype);
        }
    }
}
