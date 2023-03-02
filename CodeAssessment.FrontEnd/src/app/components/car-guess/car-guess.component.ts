import { Component, OnInit } from '@angular/core';
import { CarDto } from 'src/app/models/car-dto';
import { GuessCar } from 'src/app/models/guess-car';
import { CarService } from 'src/app/services/car-service.service';

@Component({
  selector: 'app-car-guess',
  templateUrl: './car-guess.component.html',
  styleUrls: ['./car-guess.component.css']
})
export class CarGuessComponent implements OnInit {

  public guessCars: GuessCar[] = [];
  constructor(private carService:CarService) { 
  }
  
  ngOnInit(): void {
    this.carService.getAllCars().subscribe({
      next: (cars: CarDto[]) => {
        this.guessCars = cars.map(car=> new GuessCar(car))
      },
      error: (e) => console.log(e)
    }
    );
  }

  public checkGuess(guessCar: GuessCar): void {
    const guessDifference = Math.abs(guessCar.priceGuess - guessCar.car.price);
    if (guessDifference <= 5000) {
      guessCar.success = true;
    } else {
      guessCar.success = false;
    }
  }

}
