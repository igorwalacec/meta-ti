import axios from 'axios';

const geoApi = axios.create({
    baseURL: 'https://app.geocodeapi.io/api/v1/',
    // search?text=Wien,Österreich&apikey=9cc98e30-18de-11eb-8812-6dcaf3454ed0
    responseType: "json"
});

export default geoApi;
