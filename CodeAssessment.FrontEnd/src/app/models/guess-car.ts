import { CarDto } from "./car-dto";

export class GuessCar{
    public car: CarDto;
    public priceGuess!: number;
    public success!: boolean;

    constructor(car:CarDto){
        this.car = car;
    }
}