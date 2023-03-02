using CodingAssessment.Application.Features.Cars.CommonDto;
using CodingAssessment.Domain.Features.Cars;
using MediatR;

namespace CodingAssessment.Application.Features.Cars.Commands
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CarDto>
    {
        private readonly ICarsRepository _carsRepository;

        public CreateCarCommandHandler(ICarsRepository carsRepository)
        {
            this._carsRepository = carsRepository;
        }

        public async Task<CarDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = new Car(request.Id, request.Make, request.Model, request.Year, request.Doors, request.Color,
                request.Price);

            Car insertedCar = await this._carsRepository.Create(car);

            return new CarDto(insertedCar);
        }
    }
}
