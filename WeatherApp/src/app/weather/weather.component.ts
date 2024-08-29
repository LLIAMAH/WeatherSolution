import {Component, inject, OnDestroy, OnInit} from '@angular/core';
import {ICountryDto, ITemperature, ITemperatureRequest} from "../services/interfaces/interfaces";
import {WeatherDataService} from "../services/weather-data.service";
import {Subscription} from "rxjs";
import {ReactiveFormsModule} from "@angular/forms";
import {WeatherFormComponent} from "./weather-form/weather-form.component";
import {NgForOf, NgIf} from "@angular/common";
import {provideHttpClient, withInterceptorsFromDi} from "@angular/common/http";
import {bootstrapApplication} from "@angular/platform-browser";

@Component({
  selector: 'app-weather',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    WeatherFormComponent,
    NgForOf,
    NgIf
  ],
  templateUrl: './weather.component.html',
  styleUrl: './weather.component.css'
})
export class WeatherComponent implements OnInit, OnDestroy {
  countries: ICountryDto[] = [];
  temperatures: ITemperature[] = [];

  private weatherDataSrv = inject(WeatherDataService);
  private countriesSubscription: Subscription | undefined;

  constructor() { }

  onFormSubmit(request: ITemperatureRequest): void {
    this.weatherDataSrv.getTemperatures(request).subscribe((data: ITemperature[]) => {
        this.temperatures = data;
      }
    );
  }

  ngOnInit(): void {
    this.countriesSubscription = this.weatherDataSrv
      .getCountries()
      .subscribe((data: ICountryDto[]) => {
        this.countries = data;
      })
  }

  ngOnDestroy(): void {
    if (this.countriesSubscription)
      this.countriesSubscription.unsubscribe();
  }

}

