import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CarProductionModule } from './car-production/car-production.module';
import { CarProductionItemComponent } from './car-production/car-production-item/car-production-item.component';
import { CarProductionPageComponent } from './car-production/car-production-page/car-production-page.component';

@NgModule({
  declarations: [
    AppComponent,
    CarProductionItemComponent,
    CarProductionPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CarProductionModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
