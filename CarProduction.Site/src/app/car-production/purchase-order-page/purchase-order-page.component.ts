import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { IPurchaseOrder } from '../shared/purchase-order.interface';
import { PurchaseOrderService } from '../shared/purchase-order.service';

@Component({
  selector: 'app-purchase-order-page',
  templateUrl: './purchase-order-page.component.html',
  styleUrls: ['./purchase-order-page.component.css']
})
export class PurchaseOrderPageComponent implements OnInit {

  public purchaseOrders: IPurchaseOrder[] = [];
  public form!: FormGroup;

  constructor(private purchaseOrderService: PurchaseOrderService) {
    this.reloadCars();  
  }

  public ngOnInit(): void {
    this.form = new FormGroup({
      nameBuyer: new FormControl(null, [Validators.required]),
      dealershipId: new FormControl(null, [Validators.required]),
      carId: new FormControl(null, [Validators.required])
    });
  }

  private reloadCars(): void {
    this.purchaseOrderService.getPurchaseOrder().subscribe((s) => this.purchaseOrders = s );
  }


}
