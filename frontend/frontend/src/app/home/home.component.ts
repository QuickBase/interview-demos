import { Component, OnInit } from '@angular/core';
import { CountryService } from "../shared/services/http-services/country.service";
import { forkJoin } from "rxjs";
import {Country} from "../shared/models/country.model";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public countriesWithPopulation: Country[] = [];
  public countriesWithUpdatedPopulation: Country[] = [];
  public displayedColumns: string[] = ['name', 'population'];
  public isLoading = true;

  constructor(private countryService: CountryService) {}

  ngOnInit(): void {
    forkJoin({
      countriesWithPopulation: this.countryService.getAllWithPopulations(),
      countriesWithUpdatedPopulation: this.countryService.getAllWithUpdatedPopulations()
    }).subscribe(response => {
      this.transformJsonToCountryArray(response.countriesWithPopulation.body, this.countriesWithPopulation);
      this.transformJsonToCountryArray(response.countriesWithUpdatedPopulation.body, this.countriesWithUpdatedPopulation);

      this.sortByNameAscending(this.countriesWithPopulation);
      this.sortByNameAscending(this.countriesWithUpdatedPopulation);

      this.isLoading = false;
    });
  }

  private transformJsonToCountryArray(inputCountries: any[] | null, outputCountries: Country[]): void {
    const countriesWithPopulation = inputCountries != null ? inputCountries : [];

    countriesWithPopulation.forEach(country => {
      Object.keys(country).forEach((key: string) => {
        outputCountries.push({
          name: key,
          population: country[key]
        });
      });
    });
  }

  private sortByNameAscending(countries: Country[]) {
    countries.sort((a, b) => {
      const nameA = a.name != undefined ? a.name : "";
      const nameB = b.name != undefined ? b.name : "";

      return nameA > nameB ? 1 : -1
    });
  }

  public isNewRow(row: any): string {
    let className = 'gray-row';
    if (!this.countriesWithPopulation.some(country => country.name == row.name)) {
      className = 'green-row';
    }

    return className;
  }
}
