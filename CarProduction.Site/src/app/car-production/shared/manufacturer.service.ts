import { Injectable } from "@angular/core";
import { IManufacturer } from "./manufacturer.interface";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable()
export class ManufacturerService {
  private readonly apiUrl: string = 'http://localhost:4200/api/manufacturer';

  constructor(private httpClient: HttpClient) {
  }

  public getManufacturer(manufacturerId: number): Observable<IManufacturer> {
    return this.httpClient.get<IManufacturer>(`${this.apiUrl}/${manufacturerId}`);
  }
}
