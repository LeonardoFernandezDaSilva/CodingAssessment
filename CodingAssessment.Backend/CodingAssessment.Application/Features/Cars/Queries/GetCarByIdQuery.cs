using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingAssessment.Application.Features.Cars.CommonDto;
using MediatR;

namespace CodingAssessment.Application.Features.Cars.Queries
{
    public class GetCarByIdQuery : IRequest<CarDto>
    {
        public int Id { get; set; }

        public GetCarByIdQuery(int id)
        {
            this.Id= id;
        }
    }
}
