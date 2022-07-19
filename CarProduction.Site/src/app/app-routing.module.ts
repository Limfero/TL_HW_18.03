import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarProductionPageComponent } from "./car-production/car-production-page/car-production-page.component";

const routes: Routes = [
  {
      path: '**',
      component: CarProductionPageComponent
  }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
