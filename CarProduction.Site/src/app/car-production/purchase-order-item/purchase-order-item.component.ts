import { Component, Input, OnInit } from '@angular/core';
import { IPurchaseOrder } from '../shared/purchase-order.interface';

@Component({
  selector: 'app-purchase-order-item',
  templateUrl: './purchase-order-item.component.html',
  styleUrls: ['./purchase-order-item.component.css']
})
export class PurchaseOrderItemComponent implements OnInit {
  @Input() public purchaseOrder!: IPurchaseOrder;
  constructor() { }

  ngOnInit(): void {
  }

}
