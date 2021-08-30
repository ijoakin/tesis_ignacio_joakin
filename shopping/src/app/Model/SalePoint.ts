export class SalePoint {
    id: number;
    description: string;
    address: string;
    countryId: number;
    country: string;
    countryCategory: string;

    constructor(id: number, description: string, address: string, country: string,
      countryId: number,
      countryCategory: string,
    ) {
        this.id = id;
        this.description = description;
        this.address = address;
        this.country = country;
        this.countryId = countryId;
        this.countryCategory = countryCategory;
    }
}
