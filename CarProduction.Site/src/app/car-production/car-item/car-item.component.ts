import { Component, EventEmitter, Input, Output } from "@angular/core";
import { ICar } from "../shared/car.interface";

@Component({
  selector: 'app-car-item',
  templateUrl: './car-item.component.html',
  styleUrls: ['./car-item.component.css']
})

export class CarItemComponent{
  @Input() public car!: ICar;
  @Output() public delete: EventEmitter<ICar> = new EventEmitter<ICar>();
  constructor(){ }

  public deleteCar(): void {
    this.delete.emit(this.car);
  }
}
