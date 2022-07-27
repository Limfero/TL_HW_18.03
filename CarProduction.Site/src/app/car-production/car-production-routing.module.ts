import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { CarProductionComponent } from "./car-production/car-production.component";
import { CarDealershipPageComponent } from "./car-dealership-page/car-dealership-page.component";
import { CarPageComponent } from "./car-page/car-page.component";
import { CarsInDealershipPageComponent } from "./cars-in-dealership-page/cars-in-dealership-page.component";
import { ManufacturerPageComponent } from "./manufacturer-page/manufacturer-page.component";
import { PurchaseOrderPageComponent } from "./purchase-order-page/purchase-order-page.component";

const routes: Routes = [
  {
    path: 'home',
    component: CarProductionComponent
  },
  {
    path: 'car-dealership-list',
    component: CarDealershipPageComponent
  },
  {
    path: 'car-list',
    component: CarPageComponent
  },
  {
    path: 'cars-in-dealership-list/:carDealershipId',
    component: CarsInDealershipPageComponent
  },
  {
    path: 'manufacturer/:infoManufacturerId',
    component: ManufacturerPageComponent
  },
  {
    path: 'purchase-order-list',
    component: PurchaseOrderPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class CarProductionRoutingModule { }
