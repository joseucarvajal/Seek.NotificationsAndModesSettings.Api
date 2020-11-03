using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeekQ.NotificationsAndModesSettings.Api.Application.Commands;
using SeekQ.NotificationsAndModesSettings.Api.Application.Queries;
using SeekQ.NotificationsAndModesSettings.Api.Domain.ModesAggregate;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SeekQ.NotificationsAndModesSettings.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ModesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ModesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("user/{idUser}")]
        [SwaggerOperation(Summary = "Get modes settings by user")]
        public async Task<IEnumerable<GetModesByUserViewModel>> GetModesByUser(
            [FromRoute] Guid idUser
        )
        {
            return await _mediator.Send(new GetModesByUserQueryHandler.Query(idUser));
        }

        [HttpPost]
        [Route("user/toggle")]
        [SwaggerOperation(Summary = "Toggle account notification/mode setting")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Account notification/mode setting Disabled succesfully")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad Request")]
        public async Task<bool> ToggleUserModeType(
            [FromBody]ToggleUserModeTypeCommandHandler.Command usermodetype
        )
        {
            return await _mediator.Send(usermodetype);
        }
    }
}
