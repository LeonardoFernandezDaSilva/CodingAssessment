export class CarDto {
    public id: number;
    public make: string;
    public model: string;
    public year: number;
    public doors: number;
    public color: string;
    public price: number;
    public guess: number;
  
    constructor(id: number, make: string, model: string, year: number, doors: number, color: string, price: number, guess:number) {
      this.id = id;
      this.make = make;
      this.model = model;
      this.year = year;
      this.doors = doors;
      this.color = color;
      this.price = price;
      this.guess = guess;
    }
  }
  