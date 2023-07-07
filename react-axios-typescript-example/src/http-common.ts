import axios, { HeadersDefaults } from 'axios';

interface CommonHeaderProperties extends HeadersDefaults {
  Authorization: string;
}

export default axios.create({
  baseURL: 'https://geocoding.geo.census.gov/', //can  change this url when needed for api
  headers: {
    'Content-type': 'application/json',
  },
});
