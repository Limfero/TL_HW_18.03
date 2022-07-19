import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { CarProductionPageComponent } from "./car-production-page/car-production-page.component";

const routes: Routes = [
  {
    path: 'car-production',
    component: CarProductionPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class CarProductionRoutingModule { }
