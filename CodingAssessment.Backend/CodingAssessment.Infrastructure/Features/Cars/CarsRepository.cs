using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingAssessment.Domain.Exceptions;
using CodingAssessment.Domain.Features.Cars;
using CodingAssessment.Infrastructure.Mocks;

namespace CodingAssessment.Infrastructure.Features.Cars
{
    public class CarsRepository : ICarsRepository
    {
        private readonly CarsMockDatabase _database;
        public CarsRepository(CarsMockDatabase carsMockDatabase)
        {
            this._database = carsMockDatabase;
        }
        public Task<List<Car>> GetAll()
        {
            return Task.FromResult(this._database.Cars); //"Task.FromResult" would not be necessary with real asynchronous database
        }

        public Task<Car> GetById(int id)
        {
            try
            {
                var result = this._database.Cars.First(car => car.Id == id);
                return Task.FromResult(result);
            }
            catch (InvalidOperationException invalidOperationException)
            {
                throw new EntityNotFoundException(nameof(Car), $"Car with Id {id} cannot be found", invalidOperationException);
            }
        }

        public Task<Car> Create(Car car)
        {

            var exists = this._database.Cars.Any(x => x.Id == car.Id);
            if (exists)
            {
                throw new EntityAlreadyExistsException(nameof(Car),$"Car with Id {car.Id} already exists");
            }

            this._database.Cars.Add(car);
            return Task.FromResult(car);
        }

        public async Task<Car> Update(Car car)
        {
            var entityToUpdate = await this.GetById(car.Id);
    
            return entityToUpdate;
        }

        public Task Delete(int id)
        {
            var removedElements = this._database.Cars.RemoveAll(car => car.Id == id);

            if (removedElements == 0)
            {
                throw new EntityNotFoundException(nameof(Car), $"Car with Id {id} cannot be found");

            }

            return Task.CompletedTask;
        }
    }
}
