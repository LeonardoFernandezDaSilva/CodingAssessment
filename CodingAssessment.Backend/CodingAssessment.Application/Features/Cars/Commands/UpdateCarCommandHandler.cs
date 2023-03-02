using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingAssessment.Application.Features.Cars.CommonDto;
using CodingAssessment.Domain.Features.Cars;
using MediatR;

namespace CodingAssessment.Application.Features.Cars.Commands
{
    public class UpdateCarCommandHandler: IRequestHandler<UpdateCarCommand, CarDto>
    {
        private readonly ICarsRepository _carsRepository;

        public UpdateCarCommandHandler(ICarsRepository carsRepository)
        {
            this._carsRepository = carsRepository;
        }

        public async Task<CarDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var car = await this._carsRepository.GetById(request.Id);

            car.Make = request.Make;
            car.Price = request.Price;
            car.Color = request.Color;
            car.Doors = request.Doors;
            car.Model = request.Model;
            car.Year = request.Year;

            var updatedCar = await this._carsRepository.Update(car);

            var result = new CarDto(car);

            return result;

        }
    }
}
