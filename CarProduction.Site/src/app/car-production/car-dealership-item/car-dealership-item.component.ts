import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ICarDealership } from '../shared/car-dealership.interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-car-dealership-item',
  templateUrl: './car-dealership-item.component.html',
  styleUrls: ['./car-dealership-item.component.css']
})
export class CarDealershipItemComponent implements OnInit{
  constructor(private router: Router) { }
  
  @Input() public item!: ICarDealership;


  ngOnInit(): void {
  }

  public goCars(carDealershipId: number): void{
    this.router.navigate([`listCarsInDealerships/${carDealershipId}`]);
  }
}
