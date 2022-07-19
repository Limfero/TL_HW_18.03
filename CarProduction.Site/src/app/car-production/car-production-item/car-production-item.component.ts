import { Component, EventEmitter, Input, Output } from "@angular/core";
import { ICar } from "../shared/car.interface";

@Component({
  selector: 'tl-car-list-item',
  templateUrl: './car-production-item.component.html'
})

export class CarProductionItemComponent {
  @Input() public item!: ICar;
  @Output() public update: EventEmitter<ICar> = new EventEmitter<ICar>();
  @Output() public delete: EventEmitter<ICar> = new EventEmitter<ICar>();

  public deleteClicked(): void {
    this.delete.emit(this.item);
  }

  public updateClicked(): void {
    this.update.emit(this.item);
  }
}
