import {inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import {ITempFromProvider} from "./interfaces/interfaces";

@Injectable({
  providedIn: 'root'
})
export class TemperatureProviderService {
  private http = inject(HttpClient);
  private readonly _apiAddressRemote: string;
  private readonly _apiAddressApi: string;
  private readonly _apiWeatherKey: string;

  constructor() {
    this._apiWeatherKey = environment.apiUrl.apiWeatherKey;
    this._apiAddressRemote = 'https://api.openweathermap.org/data/2.5/weather';
    this._apiAddressApi = environment.apiUrl.https;
  }

  getTemperature(lat: number, long: number): Observable<ITempFromProvider> {
    return this.http.get<ITempFromProvider>(
      `${this._apiAddressRemote}?lat=${lat}&lon=${long}&units=metric&appid=${this._apiWeatherKey}`);
  }
}
