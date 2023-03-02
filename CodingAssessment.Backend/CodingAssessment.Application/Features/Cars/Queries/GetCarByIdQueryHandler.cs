using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingAssessment.Application.Features.Cars.CommonDto;
using CodingAssessment.Domain.Features.Cars;
using MediatR;

namespace CodingAssessment.Application.Features.Cars.Queries
{
    public class GetCarByIdQueryHandler: IRequestHandler<GetCarByIdQuery, CarDto>
    {
        private readonly ICarsRepository _carsRepository;

        public GetCarByIdQueryHandler(ICarsRepository carsRepository)
        {
            this._carsRepository = carsRepository;
        }
        public async Task<CarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            Car car = await _carsRepository.GetById(request.Id);
            var result = new CarDto(car);
            return result;
        }
    }
}
