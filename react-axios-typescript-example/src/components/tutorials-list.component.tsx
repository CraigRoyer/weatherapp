import { Component, ChangeEvent } from 'react';
import TutorialDataService from '../services/tutorial.service';
import { Link } from 'react-router-dom';
import { Root } from '../types/Forecast.type';

type Props = {};

type State = {
  searchTitle: string;
  searchCity: string;
  searchState: string;
  searchZip: string;
  forecast: Root;
};

export default class TutorialsList extends Component<Props, State> {
  constructor(props: Props) {
    super(props);
    this.onChangeSearchTitle = this.onChangeSearchTitle.bind(this);
    this.onChangeSearchCity = this.onChangeSearchCity.bind(this);
    this.onChangeSearchState = this.onChangeSearchState.bind(this);
    this.onChangeSearchZip = this.onChangeSearchZip.bind(this);
    this.getWeather = this.getWeather.bind(this);

    this.state = {
      searchTitle: '',
      searchCity: '',
      searchState: '',
      searchZip: '',
      forecast: [],
    };
  }

  onChangeSearchTitle(e: ChangeEvent<HTMLInputElement>) {
    const searchTitle = e.target.value;

    this.setState({
      searchTitle: searchTitle,
    });
  }
  onChangeSearchCity(ev: ChangeEvent<HTMLInputElement>) {
    const searchCity = ev.target.value;

    this.setState({
      searchCity: searchCity,
    });
  }
  onChangeSearchState(ev: ChangeEvent<HTMLInputElement>) {
    const searchState = ev.target.value;

    this.setState({
      searchState: searchState,
    });
  }
  onChangeSearchZip(ev: ChangeEvent<HTMLInputElement>) {
    const searchZip = ev.target.value;

    this.setState({
      searchZip: searchZip,
    });
  }

  getWeather() {
    TutorialDataService.getForecast(
      this.state.searchTitle,
      this.state.searchCity,
      this.state.searchState,
      this.state.searchZip
    )
      .then((response: any) => {
        this.setState({
          forecast: response.data,
        });
        console.log(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });
  }

  render() {
    const { searchTitle, searchCity, searchState, searchZip, forecast } =
      this.state;

    return (
      <div className="list row">
        <div className="col-md-8">
          <div className="input-group mb-3">
            <input
              type="text"
              className="form-control"
              placeholder="street address"
              value={searchTitle}
              onChange={this.onChangeSearchTitle}
            />
            <br></br>
            <input
              type="text"
              className="form-control"
              placeholder="city"
              value={searchCity}
              onChange={this.onChangeSearchCity}
            />
            <br></br>
            <input
              type="text"
              className="form-control"
              placeholder="state abbreviation"
              value={searchState}
              onChange={this.onChangeSearchState}
            />
            <br></br>
            <input
              type="text"
              className="form-control"
              placeholder="zip code"
              value={searchZip}
              onChange={this.onChangeSearchZip}
            />
            <br></br>
            <div className="input-group-append">
              <button
                className="btn btn-outline-secondary"
                type="button"
                onClick={this.getWeather} //this is referencing the function
              >
                Search
              </button>
            </div>
          </div>
        </div>
        <div className="col-md-6">
          <div className="forecast-container">
            {forecast.map((a) => (
              <div
                className={
                  a.isDaytime || a.number === 1
                    ? 'true' + ' day' + a.number
                    : 'classFalse'
                }
              >
                <h2 className="day-of-the-week">{a.name}</h2>
                <img className="icon" src={a.icon}></img>
                <div className="space"></div>
                <p
                  className={
                    a.number === 1 || a.number === 2
                      ? 'longforecast'
                      : 'forecastFalse'
                  }
                >
                  {a.detailedForecast}
                </p>
                <h3 className="temperature">{a.temperature}°F</h3>
              </div>
            ))}
          </div>
        </div>
      </div>
    );
  }
}
