//import http from '../http-common';
import axios from 'axios';
import { Root } from '../types/Forecast.type';
class TutorialDataService {
  getForecast(street: string, city: string, state: string, zip: string) {
    return axios.get<Root>(
      `https://localhost:44315/weather/forecast/${street}/${city}/${state}/${zip}`
    );
  }
}

export default new TutorialDataService();
