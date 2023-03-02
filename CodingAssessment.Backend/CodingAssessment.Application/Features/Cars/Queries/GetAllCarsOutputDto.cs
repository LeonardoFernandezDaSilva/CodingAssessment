using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingAssessment.Application.Features.Cars.CommonDto;

namespace CodingAssessment.Application.Features.Cars.Queries
{
    public class GetAllCarsOutputDto
    {
        public List<CarDto> Results { get; set; }
        public int Total { get; set; }

        public GetAllCarsOutputDto(List<CarDto> cars)
        {
            Results = cars;
            Total = cars.Count;
        }
    }
}
