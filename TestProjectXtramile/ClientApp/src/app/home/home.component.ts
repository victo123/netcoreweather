import { NgModule, Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public forecasts: WeatherForecast;
  errorMsg: string;
  countryList: string[];
  cityList: string[];

  form = new FormGroup({
    country: new FormControl('', Validators.required)
  });

  get f() {
    return this.form.controls;
  }

  changeCountry(e) {
    var countryId = this.form.get('country').value;

    this.http.get<string[]>(environment.apiURL + 'city/getcity?country=' + countryId ).subscribe(result => {
      this.cityList = result;
    }, error => console.error(error));
  }

  changeCity(e) {
    var cityId = this.form.get('country').value;

    this.http.get<WeatherForecast>(environment.apiURL + 'weather/getweatherbycity?cityid=' + cityId).subscribe(result => {
      console.log(result);
      if (result != null) {
        this.forecasts = result;
        this.errorMsg = null;
      }
      else {
        this.forecasts = null;
        this.errorMsg = "Something wrong with WheaterAPI. Please check later";
      }
    }, error => console.error(error));
  }

  constructor(private http: HttpClient) {
    http.get<string[]>(environment.apiURL + 'country/getcountrylist').subscribe(result => {
      this.countryList = result;
    }, error => console.error(error));
  };
}

interface WeatherForecast {
  date: string;
  temperatureInCelcius: number;
  temperatureInFahrenheith: number;
  summary: string;
  location: string;
  time: string;
  wind: string;
  visibility: number;
  skyCondition: string;
  dewpoint: number;
  relativehumidity: number;
  pressure: number;
}
