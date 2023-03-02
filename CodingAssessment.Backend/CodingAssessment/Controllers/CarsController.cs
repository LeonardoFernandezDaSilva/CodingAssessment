using CodingAssessment.API.Middlewares;
using CodingAssessment.Application.Features.Cars.Commands;
using CodingAssessment.Application.Features.Cars.CommonDto;
using CodingAssessment.Application.Features.Cars.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.API.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        public readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<GetAllCarsOutputDto> GetAllServiceRequests()
        {
            var result = await this._mediator.Send(new GetAllCarsQuery());

            return result;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<CarDto> GetServiceRequestById(int id)
        {
            var result = await this._mediator.Send(new GetCarByIdQuery(id));

            return result;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CarDto))]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateServiceRequest(CreateCarCommand command)
        {
            var result = await this._mediator.Send(command);

            return this.CreatedAtAction(nameof(this.CreateServiceRequest), result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task DeleteServiceRequest(int id)
        {
            await this._mediator.Send(new DeleteCarCommand(id));

            this.Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateServiceRequest(int id, UpdateCarCommand command)
        {
            command.Id = id;//This can be improved
            var result = await this._mediator.Send(command);

            return this.Ok(result);
        }



    }
}
