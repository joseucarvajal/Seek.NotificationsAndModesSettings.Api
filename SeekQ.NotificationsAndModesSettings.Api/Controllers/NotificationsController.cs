using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeekQ.NotificationsAndModesSettings.Api.Application.Queries;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
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
        [Route("user/{idUser}")]
        [SwaggerOperation(Summary = "Get notifications settings by user")]
        public async Task<IEnumerable<GetNotificationsByUserViewModel>> GetNotificationsByUser(
            [FromRoute] Guid idUser
        )
        {
            return await _mediator.Send(new GetNotificationsByUserQueryHandler.Query(idUser));
        }
    }
}
