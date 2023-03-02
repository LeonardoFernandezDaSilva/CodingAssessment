﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingAssessment.Domain.Features.Cars;

namespace CodingAssessment.Infrastructure.Mocks
{
    public class CarsMockDatabase
    {
        public CarsMockDatabase()
        {
            Cars = new List<Car>
            {
                new Car(1, "Audi", "R8", 2018, 2, "Red", 79995),
                new Car(2, "Tesla", "3", 2018, 4, "Black", 54995),
                new Car(3, "Porsche", "911 991", 2020, 2, "White", 155000),
                new Car(4, "Mercedes-Benz", "GLE 63S", 2021, 5, "Blue", 83995),
                new Car(5, "BMW", "X6 M", 2020, 5, "Silver", 62995)
            };
        }
        public List<Car> Cars { get; set; }
    }
}
