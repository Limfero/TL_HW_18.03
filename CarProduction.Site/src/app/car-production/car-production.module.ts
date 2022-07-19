import { NgModule } from "@angular/core";
import { CarProductionPageComponent } from "./car-production-page/car-production-page.component";
import { CarProductionRoutingModule } from "./car-production-routing.module";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { MatListModule } from "@angular/material/list";
import { CommonModule } from "@angular/common";
import { CarProductionItemComponent } from "./car-production-item/car-production-item.component";
import { MatIconModule } from "@angular/material/icon";
import { CarService } from "./shared/car.service";
import { HttpClientModule } from "@angular/common/http";
import { ReactiveFormsModule } from "@angular/forms";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatTabsModule } from '@angular/material/tabs';

@NgModule({
  declarations: [
    CarProductionPageComponent,
    CarProductionItemComponent
  ],
  imports: [
    HttpClientModule,
    MatButtonModule,
    MatCardModule,
    MatListModule,
    CarProductionModule,
    CommonModule,
    MatIconModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatTabsModule
  ],
  providers: [
    CarService
  ]
})
export class CarProductionModule { }
