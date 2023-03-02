using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CodingAssessment.Application.Features.Cars.Queries
{
    public class GetAllCarsQuery : IRequest<GetAllCarsOutputDto>
    {
    }
}
