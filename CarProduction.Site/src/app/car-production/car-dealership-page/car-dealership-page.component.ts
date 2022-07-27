import { Component, OnInit } from '@angular/core';
import { ICarDealership } from '../shared/car-dealership.interface';
import { CarDealershipService } from '../shared/car-dealership.service';
import { AbstractControl, FormControl, FormGroup, Validators } from "@angular/forms";


@Component({
  templateUrl: './car-dealership-page.component.html',
  styleUrls: ['./car-dealership-page.component.css'],
  providers: [CarDealershipService]
})
export class CarDealershipPageComponent {
  public carDealerships!: ICarDealership[];
  public form!: FormGroup;

  constructor(private carDealershipService: CarDealershipService) {
    this.reloadCarDealerships();  
  }

  private reloadCarDealerships(): void {
    this.carDealershipService.getCarDealerships().subscribe(t => {
      this.carDealerships = Object.assign([], t)});
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      dealershipId: new FormControl(null, [Validators.required]),
      nameDealership: new FormControl(null, [Validators.required]),
      supplier: new FormControl(null, [Validators.required])
    });
    this.form.controls["DealershipId"].setValue(0);
  }

  public addCarDealershipItem(): void{
    if (this.form.invalid) {
      return;
  }
  this.carDealershipService.addCarDealership({
    dealershipId: 0,
    nameDealership: this.nameDealershipControl.value,
    supplier: this.supplierControl.value,
  }).subscribe(() => {
      this.reloadCarDealerships();
      this.form.markAsUntouched();
  });
  }

  get nameDealershipControl(): AbstractControl{
    return this.form.get("nameDealership")!;
  }

  get supplierControl(): AbstractControl{
    return this.form.get("supplier")!;
  }
}
