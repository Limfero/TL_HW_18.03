import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarProductionComponent } from './car-production/car-production/car-production.component';

const routes: Routes = [
  {
    path: '',
    component: CarProductionComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
