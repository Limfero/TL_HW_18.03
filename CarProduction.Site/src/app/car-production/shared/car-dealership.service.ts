import { Injectable } from "@angular/core";
import { ICarDealership } from "./car-dealership.interface";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class CarDealershipService {
  private readonly apiUrl: string = 'http://localhost:4200/api/carDealership';

  constructor(private httpClient: HttpClient) {
  }

  public getCarDealerships(): Observable<ICarDealership[]> {
    return this.httpClient.get<ICarDealership[]>(`${this.apiUrl}/listCarDealerships`);
  }

  public addCarDealership(carDealership: ICarDealership): Observable<null> {
    return this.httpClient.post<null>(`${this.apiUrl}/createCarDealerships`, carDealership);
}
}
