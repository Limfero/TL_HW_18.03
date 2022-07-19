import { Injectable } from "@angular/core";
import { ICar } from './car.interface';
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class CarService {
  private readonly apiUrl: string = 'http://localhost:4200/api/Car';

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

  public getCar(id: number): Observable<ICar> {
    return this.httpClient.get<ICar>(`${this.apiUrl}/${id}`);
  }

  public updateCar(id: number): Observable<object> {
    return this.httpClient.put(`${this.apiUrl}/${id}/update`, "json");
  }
}
