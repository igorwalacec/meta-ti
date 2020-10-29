export interface ResponseGeoApi {
    features: {
        type: string;
        geometry: {
            type: string;
            coordinates: Array<number>
        };
        properties: {
            country: string;
            name: string;
            housenumber: string;
            street: string;
        }
    }[]
}