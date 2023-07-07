using Capstone.Models;
using Capstone.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        /*  private readonly LatLongApiService latLongApiService;
          private readonly WeatherApiService weatherApiService;

              public WeatherController(LatLongApiService _latLongApiService, WeatherApiService _weatherApiService)
              {
                  latLongApiService = _latLongApiService;
                  weatherApiService = _weatherApiService;
              }*/

        protected static RestClient client = null;
        protected static RestClient foreCastClient = new RestClient("https://api.weather.gov/points/");
        protected static RestClient dadJokeClient = new RestClient("https://icanhazdadjoke.com/");
       
        [HttpGet("dadJoke")]
        public DadJoke GetPublicAPIQuery()
        {
            RestRequest request = new RestRequest();
            IRestResponse<DadJoke> response = dadJokeClient.Get<DadJoke>(request);

            CheckForError(response);

            return response.Data;

        }
        public Root GetGeoLocationResultsFromAddress(Address address)
        {
            RestClient latLongClient = new RestClient("https://geocoding.geo.census.gov/geocoder/locations/address?street=" + address.Street + "&city=" + address.City + "&state=" + address.State + "&zip=" + address.Zip + "&benchmark=Public_AR_Census2020&format=json");
            RestRequest request = new RestRequest();
            IRestResponse<Root> response = latLongClient.Get<Root>(request);
    

        CheckForError(response);

            return response.Data;

        }

     
        public string GetForecastLinkFromLatLong(Coordinates coordinates)
        {
            RestClient foreCastClient = new RestClient("https://api.weather.gov/points/" + coordinates.y + "," + coordinates.x);
            RestRequest request = new RestRequest();
            IRestResponse<RootLinkForForecast> response = foreCastClient.Get<RootLinkForForecast>(request);

            //CheckForError(response);

            RootLinkForForecast rootLinkForForecast = response.Data;
            return rootLinkForForecast.properties.forecast;

        }

        public List<ForecastPeriod> GetPeriodsListFromForecastLink(string forecastLink)
        {
            RestClient foreCastClient = new RestClient(forecastLink);
            RestRequest request = new RestRequest();
            IRestResponse<RootForecastClasses> response = foreCastClient.Get<RootForecastClasses>(request);
            
            //CheckForError(response);

            RootForecastClasses forecasts = response.Data;
            return forecasts.properties.periods;

        }

        private void CheckForError(IRestResponse response)
        {
            if (!response.IsSuccessful)
            {
                //TODO: Write a message into a log file for future. 

                throw new HttpRequestException($"There was an error in the call to the server {response.StatusCode}");
            }
        }
    
            [HttpGet("forecast/{street}/{city}/{state}/{zip}")]
            public ActionResult<List<ForecastPeriod>> GetWeatherByAddress(string street, string city, string state, string zip){

               Address address = new Address(street,city,state,zip);
                Root root = GetGeoLocationResultsFromAddress(address);

              string forecastLink = GetForecastLinkFromLatLong(root.result.addressMatches[0].coordinates);
               return GetPeriodsListFromForecastLink(forecastLink);
                

            }}}
            