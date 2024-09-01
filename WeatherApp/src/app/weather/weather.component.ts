import {Component, inject, OnDestroy, OnInit} from '@angular/core';
import {ICityDto, ICountryDto, ITemperature, ITemperatureRequest} from "../services/interfaces/interfaces";
import {WeatherDataService} from "../services/weather-data.service";
import {Subscription} from "rxjs";
import {ReactiveFormsModule} from "@angular/forms";
import {WeatherFormComponent} from "./weather-form/weather-form.component";
import {NgForOf, NgIf} from "@angular/common";
import {WeatherCollectComponent} from "./weather-collect/weather-collect.component";

@Component({
  selector: 'app-weather',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    WeatherFormComponent,
    NgForOf,
    NgIf,
    WeatherCollectComponent
  ],
  templateUrl: './weather.component.html',
  styleUrl: './weather.component.css'
})
export class WeatherComponent implements OnInit, OnDestroy {
  citiesListFull: ICityDto[] = [];
  countries: ICountryDto[] = [];
  temperatures: ITemperature[] = [];

  private weatherDataSrv = inject(WeatherDataService);
  private countriesSubscription: Subscription | undefined;
  private citiesSubscription: Subscription | undefined;


  constructor() { }

  onFormSubmit(request: ITemperatureRequest): void {
    this.weatherDataSrv.getTemperatures(request).subscribe((data: ITemperature[]) => {
        this.temperatures = data;
      }
    );
  }

  ngOnInit(): void {
    this.citiesSubscription = this.weatherDataSrv
      .getCitiesFullList()
      .subscribe((data: ICityDto[]) => {
        this.citiesListFull = data;
      });

    this.countriesSubscription = this.weatherDataSrv
      .getCountries()
      .subscribe((data: ICountryDto[]) => {
        this.countries = data;
      });
  }

  ngOnDestroy(): void {
    if (this.countriesSubscription)
      this.countriesSubscription.unsubscribe();
    if (this.citiesSubscription)
      this.citiesSubscription.unsubscribe();
  }

}
