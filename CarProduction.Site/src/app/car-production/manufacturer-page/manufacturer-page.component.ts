import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from "@angular/forms";
import { IManufacturer } from '../shared/manufacturer.interface';
import { ManufacturerService } from '../shared/manufacturer.service';
import { ActivatedRoute} from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-manufacturer-page',
  templateUrl: './manufacturer-page.component.html',
  styleUrls: ['./manufacturer-page.component.css']
})
export class ManufacturerPageComponent implements OnInit {
  public manufacturer!: IManufacturer; 
  public form!: FormGroup;

  infoManufacturerId!: number;
  private subscription: Subscription;
  longtext = 'test text';

  constructor(private manufacurerSevice: ManufacturerService, private activateRoute: ActivatedRoute) {
    this.subscription = activateRoute.params.subscribe(params=>this.infoManufacturerId=params['infoManufacturerId']);
    this.getManufacturer();  
  }

  public ngOnInit(): void {
    this.form = new FormGroup({
      manufacturerId: new FormControl(null, [Validators.required]),
      nameFactory: new FormControl(null, [Validators.required]),
      headquarters: new FormControl(null, [Validators.required]),
      foundationDate: new FormControl(null, [Validators.required])
    });
  }

  private getManufacturer(): void {
    this.manufacurerSevice.getManufacturer(this.infoManufacturerId).subscribe((s) => this.manufacturer = s );
  }

}
