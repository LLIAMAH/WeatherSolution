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
