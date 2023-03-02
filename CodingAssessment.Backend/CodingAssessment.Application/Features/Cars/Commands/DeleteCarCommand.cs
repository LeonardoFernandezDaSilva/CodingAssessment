using MediatR;

namespace CodingAssessment.Application.Features.Cars.Commands
{
    public class DeleteCarCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteCarCommand(int id)
        {
            this.Id = id;
        }
    }
}
