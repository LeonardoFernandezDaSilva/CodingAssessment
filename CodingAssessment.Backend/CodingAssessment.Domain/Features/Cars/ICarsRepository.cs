using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingAssessment.Domain.Features.Cars
{
    public interface ICarsRepository
    {
        public Task<Car> Create(Car car);
        public Task<Car> GetById(int id);
        public Task<List<Car>> GetAll();
        public Task<Car> Update(Car car);
        public Task Delete(int id);
    }
}
