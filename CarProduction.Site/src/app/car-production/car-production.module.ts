import { NgModule} from "@angular/core";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatListModule } from "@angular/material/list";
import { CommonModule } from "@angular/common";
import { MatIconModule } from "@angular/material/icon";
import { HttpClientModule } from "@angular/common/http";
import { ReactiveFormsModule } from "@angular/forms";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatTabsModule } from '@angular/material/tabs';

import { CarService } from "./shared/car.service";
import { CarDealershipService } from "./shared/car-dealership.service";

import { CarItemComponent } from "./car-item/car-item.component";
import { CarPageComponent } from "./car-page/car-page.component";

import { CarProductionComponent } from "./car-production/car-production.component";
import { CarProductionRoutingModule } from "./car-production-routing.module";

import { CarDealershipPageComponent } from "./car-dealership-page/car-dealership-page.component";
import { CarDealershipItemComponent } from "./car-dealership-item/car-dealership-item.component";

import { CarsInDealershipPageComponent } from "./cars-in-dealership-page/cars-in-dealership-page.component";

import { ManufacturerService } from "./shared/manufacturer.service";
import { ManufacturerPageComponent } from './manufacturer-page/manufacturer-page.component';

import { PurchaseOrderPageComponent } from './purchase-order-page/purchase-order-page.component';
import { PurchaseOrderItemComponent } from './purchase-order-item/purchase-order-item.component';
import { PurchaseOrderService } from "./shared/purchase-order.service";
import { MenuComponent } from './menu/menu.component';

@NgModule({
  declarations: [
    CarPageComponent,
    CarItemComponent,
    CarDealershipPageComponent,
    CarDealershipItemComponent,
    CarProductionComponent,
    CarsInDealershipPageComponent,
    ManufacturerPageComponent,
    PurchaseOrderPageComponent,
    PurchaseOrderItemComponent,
    MenuComponent
  ],
  imports: [
    HttpClientModule,
    MatButtonModule,
    MatCardModule,
    MatListModule,
    CommonModule,
    MatIconModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatTabsModule,
    CarProductionRoutingModule
  ],
  providers: [
    CarService,
    CarDealershipService,
    ManufacturerService,
    PurchaseOrderService
  ]
})
export class CarProductionModule { }
