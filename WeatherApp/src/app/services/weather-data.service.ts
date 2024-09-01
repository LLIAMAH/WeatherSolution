import {inject, Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {
  ICityDto,
  ICityTemperatureInput,
  ICityTemperaturePost,
  ICountryDto,
  IResultBool,
  ITemperatureRequest
} from "./interfaces/interfaces";

@Injectable({
  providedIn: 'root'
})
export class WeatherDataService {
  private http = inject(HttpClient);
  private readonly _apiAddress: string;
  private readonly _countries: string;
  private readonly _cityByCountryId: string;
  private readonly _citiesFullList: string;
  private readonly _temperaturesList: string;
  private readonly _weatherData: string;

  constructor() {
    this._apiAddress = environment.apiUrl.https;
    this._countries = "/api/Countries";
    this._citiesFullList = "/api/Cities/GetByName";
    this._cityByCountryId = "/api/Cities/GetByCountryId";
    this._temperaturesList = "/api/Temperatures";
    this._weatherData = "/api/WeatherData";
  }

  getCitiesFullList(): Observable<ICityDto[]> {
    return this.http.get<ICityDto[]>(`${this._apiAddress}${this._citiesFullList}`);
  }

  getCountries(): Observable<ICountryDto[]> {
    return this.http.get<ICountryDto[]>(`${this._apiAddress}${this._countries}`);
  }

  getCitiesByCountryId(countryId: number): Observable<ICityDto[]> {
    return this.http.get<ICityDto[]>(`${this._apiAddress}${this._cityByCountryId}?id=${countryId}`);
  }

  getTemperatures(request: ITemperatureRequest): Observable<any> {
    return this.http.post(`${this._apiAddress}${this._temperaturesList}`, request);
  }

  postTemperature(data: ICityTemperaturePost[]): Observable<IResultBool> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.post<IResultBool>(`${this._apiAddress}${this._weatherData}`, data, {headers});
  }
}
