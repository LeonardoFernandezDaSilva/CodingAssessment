using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingAssessment.Application.Features.Cars.CommonDto;
using CodingAssessment.Domain.Exceptions;
using CodingAssessment.Domain.Features.Cars;
using MediatR;

namespace CodingAssessment.Application.Features.Cars.Queries
{
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, GetAllCarsOutputDto>
    {
        private readonly ICarsRepository _carsRepository;

        public GetAllCarsQueryHandler(ICarsRepository carsRepository)
        {
            this._carsRepository = carsRepository;
        }

        public async Task<GetAllCarsOutputDto> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            List<Car> cars = await this._carsRepository.GetAll();
           
            if (cars.Count == 0)
            {
                throw new EmptyContentException();
            }

            List<CarDto> carDtos = cars.Select(car => new CarDto(car)).ToList();

            var result = new GetAllCarsOutputDto(carDtos);
            
            return result;
        }
    }
}
