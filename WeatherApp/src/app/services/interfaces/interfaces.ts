export interface IResult<T> {
  returned: T;
  message: string | null;
}
export interface IResultBool extends IResult<boolean> { }

export interface ICountryDto {
  id: number,
  name: string,
  cities: ICityDto[]
}

export interface ICityDto {
  id: number,
  name: string,
  lat: 0,
  long: 0,
  country: ICountryDto | undefined | null
}

export interface ITemperatureRequest
{
  countryId: number,
  cityId?: number | undefined,
  from: string | Date,
  to: string | Date
}

export interface ITemperature {
  dateTime: Date,
  temperature: number
}

export interface ICityTemperatureInput {
  city: ICityDto;
  tempData: number | undefined
}

export interface ICityTemperaturePost {
  cityId: number,
  tempData: number;
}

export interface ITempFromProvider {
  main: ICurrentTemp;
}

export interface ICurrentTemp{
  temp: number;
}
