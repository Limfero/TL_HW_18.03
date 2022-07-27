import { Injectable } from "@angular/core";
import { ICar } from './car.interface';
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class CarService {
  private readonly apiUrl: string = 'http://localhost:4200/api/car';

  constructor(private httpClient: HttpClient) {
  }

  public addCar(car: ICar): Observable<null> {
    return this.httpClient.post<null>(`${this.apiUrl}/createCar`, car);
  }

  public deleteCar(id?: number): Observable<object> {
    return this.httpClient.delete(`${this.apiUrl}/${id}/delete`);
  }

  public getCars(): Observable<ICar[]> {
    return this.httpClient.get<ICar[]>(`${this.apiUrl}/listCar`);
  }

  public getCarsInDealerships(carDealershipId: number): Observable<ICar[]> {
    return this.httpClient.get<ICar[]>(`${this.apiUrl}/listCarsInDealerships/${carDealershipId}`);
  }

  public updateCar(car: ICar): Observable<null> {
    return this.httpClient.put<null>(`${this.apiUrl}/${car.carId}/update`, car);
  }
}
