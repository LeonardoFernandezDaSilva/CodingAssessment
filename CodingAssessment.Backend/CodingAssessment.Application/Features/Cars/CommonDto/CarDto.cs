using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingAssessment.Domain.Features.Cars;

namespace CodingAssessment.Application.Features.Cars.CommonDto
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Doors { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        public CarDto(Car car)
        {
            Id = car.Id;
            Make = car.Make;
            Model = car.Model;
            Year = car.Year;
            Doors = car.Doors;
            Color = car.Color;
            Price = car.Price;
        }
    }
}
