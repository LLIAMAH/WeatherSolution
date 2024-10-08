import { Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {WeatherComponent} from "./weather/weather.component";
import {ErrorComponent} from "./error/error.component";

export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'weather', component: WeatherComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: '**', component: ErrorComponent }
];
