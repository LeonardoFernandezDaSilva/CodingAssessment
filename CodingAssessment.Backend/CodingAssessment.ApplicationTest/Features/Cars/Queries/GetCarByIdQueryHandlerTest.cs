using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodingAssessment.Application.Features.Cars.CommonDto;
using CodingAssessment.Application.Features.Cars.Queries;
using CodingAssessment.Domain.Exceptions;
using CodingAssessment.Domain.Features.Cars;
using FakeItEasy;
using FluentAssertions;
using Xunit;

namespace CodingAssessment.ApplicationTest.Features.Cars.Queries
{
    public class GetCarByIdQueryHandlerTest
    {
        [Fact]
        public async Task Handle_ReturnsValidCarDto()
        {
            int carId = 1;
            var car = new Car(carId, "Audi", "R8", 2018, 2, "Red", 79995);
            var carsRepository = A.Fake<ICarsRepository>();
           
            A.CallTo(() => carsRepository.GetById(carId)).Returns(car);

            var handler = new GetCarByIdQueryHandler(carsRepository);
            var query = new GetCarByIdQuery(carId);

            var result = await handler.Handle(query, CancellationToken.None);

            result.Should().NotBeNull();
            result.Id.Should().Be(car.Id);
            result.Make.Should().Be(car.Make);
            result.Model.Should().Be(car.Model);
            result.Year.Should().Be(car.Year);
            result.Doors.Should().Be(car.Doors);
            result.Color.Should().Be(car.Color);
            result.Price.Should().Be(car.Price);
        }

        [Fact]
        public async Task Handle_ThrowsException_WhenCarNotFound()
        {
            int carId = 1;

            var carsRepository = A.Fake<ICarsRepository>();
            A.CallTo(() => carsRepository.GetById(A<int>.Ignored)).Throws<EntityNotFoundException>();

            var handler = new GetCarByIdQueryHandler(carsRepository);
            var query = new GetCarByIdQuery(carId);

            Func<Task<CarDto>> action = async () => await handler.Handle(query, CancellationToken.None);

            await action.Should().ThrowAsync<EntityNotFoundException>();
        }
    }
}
