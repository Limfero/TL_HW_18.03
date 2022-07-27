import { Injectable } from "@angular/core";
import { ICar } from './car.interface';
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { IPurchaseOrder } from "./purchase-order.interface";

@Injectable()
export class PurchaseOrderService {
  private readonly apiUrl: string = 'http://localhost:4200/api/purchaseOrder';

  constructor(private httpClient: HttpClient) {
  }

  public getPurchaseOrder(): Observable<IPurchaseOrder[]> {
    return this.httpClient.get<IPurchaseOrder[]>(`${this.apiUrl}/listPurchaseOrder`);
  }

}
