using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingAssessment.Application.Features.Cars.CommonDto;
using MediatR;

namespace CodingAssessment.Application.Features.Cars.Commands
{
    public class UpdateCarCommand : IRequest<CarDto>
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Doors { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
    }
}
