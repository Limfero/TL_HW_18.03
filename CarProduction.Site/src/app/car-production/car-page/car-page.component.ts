import { Component, OnInit } from '@angular/core';
import { ICar } from "../shared/car.interface";
import { CarService } from "../shared/car.service";
import { AbstractControl, FormControl, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-car-page',
  templateUrl: './car-page.component.html',
  styleUrls: ['./car-page.component.css'],
  providers: [
    CarService
  ]
})
export class CarPageComponent implements OnInit {
  public cars: ICar[] = [];
  public form!: FormGroup;

  constructor(private carService: CarService, private route: ActivatedRoute) {
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
    this.carService.getCars().subscribe((s) => this.cars = s );
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
      manufacturerId: this.manufacturerIdControl.value
    }).subscribe(() => {
      this.reloadCars();
      this.modelControl.setValue(null),
      this.buildDataControl.setValue(null),
      this.priceControl.setValue(null),
      this.manufacturerIdControl.setValue(null),
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
      manufacturerId: this.manufacturerIdControl.value
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
