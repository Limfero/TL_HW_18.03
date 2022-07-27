import { Component, OnInit } from '@angular/core';
import { ICar } from "../shared/car.interface";
import { CarService } from "../shared/car.service";
import { AbstractControl, FormControl, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute} from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-cars-in-dealership-page',
  templateUrl: './cars-in-dealership-page.component.html',
  styleUrls: ['./cars-in-dealership-page.component.css'],
  providers: [
    CarService
  ]
})
export class CarsInDealershipPageComponent implements OnInit {
  public cars: ICar[] = [];
  public form!: FormGroup;

  carDealershipId!: number;
  private subscription: Subscription;

  constructor(private carService: CarService, private activateRoute: ActivatedRoute) {
    this.subscription = activateRoute.params.subscribe(params=>this.carDealershipId=params['carDealershipId']);
    this.reloadCars();  
  }

  public ngOnInit(): void {
    this.form = new FormGroup({
      carId: new FormControl(null, [Validators.required]),
      model: new FormControl(null, [Validators.required]),
      buildData: new FormControl(null, [Validators.required]),
      price: new FormControl(null, [Validators.required]),
      manufacturerId: new FormControl(null, [Validators.required])
    });
  }

  private reloadCars(): void {
    this.carService.getCarsInDealerships(this.carDealershipId).subscribe((s) => this.cars = s );
  }

  public addCar(): void {
    if (this.form.invalid) {
      return;
    }
    this.carService.addCar({
      carId: 0,
      model: this.modelControl.value,
      buildData: this.buildDataControl.value,
      price: this.priceControl.value,
      manufacturerId: this.carDealershipId
    }).subscribe(() => {
      this.reloadCars();
      this.form.markAsUntouched();
    });
  }

  public deleteCar(car: ICar): void {
    this.carService.deleteCar(car.carId).subscribe(() => {
      this.reloadCars();
    });
  }

  public updateCar(): void {
    if (this.form.invalid) {
      return;
    }

    this.carService.updateCar({
      carId: this.carIdControl.value,
      model: this.modelControl.value,
      buildData: this.buildDataControl.value,
      price: this.priceControl.value,
      manufacturerId: this.carDealershipId
    }).subscribe(() => {
      this.reloadCars();
      this.form.markAsUntouched()
    })

  }

  get carIdControl(): AbstractControl {
    return this.form.get("carId")!;
  }

  get buildDataControl(): AbstractControl {
    return this.form.get("buildData")!;
  }

  get priceControl(): AbstractControl {
    return this.form.get("price")!;
  }

  get modelControl(): AbstractControl {
    return this.form.get("model")!;
  }

  get manufacturerIdControl(): AbstractControl {
    return this.form.get("manufacturerId")!;
  }
}
