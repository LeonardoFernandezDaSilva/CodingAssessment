using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingAssessment.Domain.Features.Cars;
using MediatR;

namespace CodingAssessment.Application.Features.Cars.Commands
{
    public class DeleteCarCommandHandler:IRequestHandler<DeleteCarCommand, Unit>
    {
        private readonly ICarsRepository _carsRepository;

        public DeleteCarCommandHandler(ICarsRepository carsRepository)
        {
            this._carsRepository = carsRepository;
        }

        public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            await this._carsRepository.Delete(request.Id);

            return Unit.Value;
        }
    }
}
