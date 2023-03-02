import { CarDto } from "./car-dto";

export class GetAllCarsOutputDto {
  public results!: CarDto[];
  public total!: number;
}
