import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { GetAllCarsOutputDto } from '../models/get-all-cars-output-dto';
import { CarDto } from '../models/car-dto';


@Injectable({
  providedIn: 'root'
})
export class CarService {

constructor(@Inject('BASE_API_URL') baseUrl: string,private http: HttpClient) { 
  this.baseUrl = baseUrl
}

private baseUrl: string;
private carsUrl:string = '/api/cars';

  getAllCars(): Observable<CarDto[]> {
    return this.http.get<GetAllCarsOutputDto>(this.baseUrl+this.carsUrl).pipe(
      map((response: GetAllCarsOutputDto) => response.results)
    );}  
}


