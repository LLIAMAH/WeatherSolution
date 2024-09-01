import {Component, inject, Input, OnChanges, SimpleChanges} from '@angular/core';
import {ICityDto, ICityTemperatureInput, IResultBool, ITempFromProvider} from "../../services/interfaces/interfaces";
import {WeatherDataService} from "../../services/weather-data.service";
import {TemperatureProviderService} from "../../services/temperature-provider.service";
import {NgForOf} from "@angular/common";
import {forkJoin, map, Observable, Subscription} from "rxjs";

@Component({
  selector: 'app-weather-collect',
  standalone: true,
  imports: [
    NgForOf
  ],
  templateUrl: './weather-collect.component.html',
  styleUrl: './weather-collect.component.css'
})
export class WeatherCollectComponent implements OnChanges {
  @Input()
  citiesListFull: ICityDto[] = [];

  private weatherDataSrv = inject(WeatherDataService);
  private temperatureProviderSrv = inject(TemperatureProviderService);

  temperatureData: ICityTemperatureInput[] = [];

  ngOnChanges(changes: SimpleChanges) {
    /*if (changes["citiesListFull"] && this.citiesListFull) {
      this.getTemperatures();
    }*/
  }

  getTemperatures() {
    const temperatureObservables = this.citiesListFull.map((item: ICityDto) =>
      this.temperatureProviderSrv.getTemperature(item.lat, item.long).pipe(
        map((data: ITempFromProvider) => ({
          city: item,
          tempData: data.main.temp
        }))
      )
    );

    forkJoin(temperatureObservables).subscribe((temperatureData: ICityTemperatureInput[]) => {
      this.temperatureData = temperatureData;

      this.weatherDataSrv.postTemperature(
        this.temperatureData.map((input: ICityTemperatureInput) => ({
          cityId: input.city.id,
          tempData: input.tempData ?? 0
        }))
      ).subscribe((data: IResultBool) => {
        console.log(data);
      });
    });
  }

}
