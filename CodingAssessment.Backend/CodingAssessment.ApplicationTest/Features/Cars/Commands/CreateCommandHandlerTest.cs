using CodingAssessment.Application.Features.Cars.Commands;
using CodingAssessment.Domain.Features.Cars;
using FakeItEasy;
using FluentAssertions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CodingAssessment.ApplicationTest.Features.Cars.Commands
{
    public class CreateCommandHandlerTest
    {
        [Fact]
        public async Task Handle_WhenCreationIsPerformedCorrecty_ReturnsCreatedCard()
        {

            var command = new CreateCarCommand
            {
                Id = 1,
                Make = "Audi",
                Model = "R8",
                Year = 2018,
                Doors = 2,
                Color = "Red",
                Price = 79995
            };

            Car car = new Car(1, "Audi", "R8", 2018, 2, "Red", 79995);
            ICarsRepository carsRepository = A.Fake<ICarsRepository>();
            A.CallTo(() => carsRepository.Create(A<Car>.Ignored)).Returns(car);

            var handler = new CreateCarCommandHandler(carsRepository);

            var result = await handler.Handle(command, CancellationToken.None);

            result.Should().NotBeNull();
            result.Id.Should().Be(command.Id);
            result.Make.Should().Be(command.Make);
            result.Model.Should().Be(command.Model);
            result.Year.Should().Be(command.Year);
            result.Doors.Should().Be(command.Doors);
            result.Color.Should().Be(command.Color);
            result.Price.Should().Be(command.Price);
        }

    }
}
