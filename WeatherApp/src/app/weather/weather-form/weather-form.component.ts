import {Component, EventEmitter, OnDestroy, OnInit, Output} from '@angular/core';
import {ICityDto, ICountryDto} from "../../services/interfaces/interfaces";
import {FormBuilder, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {Subscription} from "rxjs";
import {WeatherDataService} from "../../services/weather-data.service";
import {NgForOf, NgIf} from "@angular/common";
//import {HttpClientModule} from "@angular/common/http";

@Component({
  selector: 'app-weather-form',
  standalone: true,
  //imports: [HttpClientModule],
  templateUrl: './weather-form.component.html',
  imports: [
    ReactiveFormsModule,
    NgIf,
    NgForOf
  ],
  styleUrl: './weather-form.component.css'
})
export class WeatherFormComponent implements OnInit, OnDestroy {

  @Output()
  submitForm = new EventEmitter<any>();

  countries: ICountryDto[] = [];
  cities: ICityDto[] = [];
  weatherForm: FormGroup;
  private subscriptions: Subscription[] = [];

  constructor(private formBuilder: FormBuilder,
              private weatherDataSrv: WeatherDataService) {
    this.weatherForm = this.formBuilder.group({
      country: ['', Validators.required],
      city:[''],
      from:['',Validators.required],
      to:['',Validators.required]
    })
  }

  ngOnInit(): void {
    this.subscriptions.push(
      this.weatherDataSrv.getCountries().subscribe((data: ICountryDto[]) => {
        this.countries = data;
      })
    );

    this.weatherForm?.get('country')?.valueChanges.subscribe(countryId => {
      if(countryId){
        this.subscriptions.push(
          this.weatherDataSrv.getCitiesByCountryId(countryId).subscribe((data: ICityDto[]) => {
            this.cities = data;
          })
        )
      }
    });
  }

  onSubmit():void {
    if (this.weatherForm && this.weatherForm.valid) {
      const formValue = this.weatherForm.value;
      const request = {
        countryId: formValue.country,
        cityId: formValue.city || undefined,
        from: formValue.from,
        to: formValue.to
      };

      this.submitForm.emit(request);
    }
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }

}
