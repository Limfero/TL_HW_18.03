import { Component, OnInit } from '@angular/core';
import { ICar } from "../shared/car.interface";
import { CarService } from "../shared/car.service";
import { AbstractControl, FormControl, FormGroup, Validators } from "@angular/forms";

@Component({
  templateUrl: './car-production-page.component.html',
  styleUrls: ['./car-production-page.component.css'],
  providers: [CarService]
})
export class CarProductionPageComponent implements OnInit {
  public inProgressItems!: ICar[];
  public doneItems!: ICar[];

  public form!: FormGroup;

  constructor(private carService: CarService) {
    this.reloadCars();
  }

  private reloadCars(): void {
    this.carService.getCars().subscribe()
  }

  public ngOnInit(): void {
    this.form = new FormGroup({
      title: new FormControl(null, [Validators.required])
    });
  }

  public addItem(): void {
    if (this.form.invalid) {
      return;
    }
    this.carService.addCar({
      Model: this.titleControl.value,
      BuildData: this.titleControl.value,
      Price: this.titleControl.value,
      ManufacturerId: this.titleControl.value

    }).subscribe(() => {
      this.reloadCars();
      this.titleControl.setValue(null);
      this.form.markAsUntouched();
    });
  }

  public deleteCar(car: ICar): void {
    this.carService.deleteCar(car.CarId).subscribe(() => {
      this.reloadCars();
    });
  }

  get titleControl(): AbstractControl {
    return this.form.get("title")!;
  }
}
