import {inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {Observable} from "rxjs";
import {ICityDto, ICountryDto, ITemperatureRequest} from "./interfaces/interfaces";

@Injectable({
  providedIn: 'root'
})
export class WeatherDataService {
  private http = inject(HttpClient);
  private readonly _apiAddress: string;
  private readonly _countries: string;
  private readonly _cityByCountryId: string;

  constructor() {
    this._apiAddress = environment.apiUrl.https;
    this._countries = "/api/Countries";
    this._cityByCountryId = "/api/Cities/GetByCountryId";
  }

  //getCountries(): Observable<ICountryDto> {
  getCountries(): Observable<any> {
    return this.http.get(`${this._apiAddress}${this._countries}`);
  }

  //getCitiesByCountryId(countryId: number): Observable<ICityDto> {
  getCitiesByCountryId(countryId: number): Observable<any> {
    return this.http.get(`${this._apiAddress}${this._cityByCountryId}?id=${countryId}`);
  }

  getTemperatures(request: ITemperatureRequest): Observable<any> {
    return this.http.post(`${this._apiAddress}/api/Temperatures`, request);
  }

}
