import { Component, Inject, OnInit } from '@angular/core';
import { Search } from 'src/app/Model/Search';
import { SearchService } from 'src/app/Services/search.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html'
})
export class SearchComponent implements OnInit {
  searches: Search[];
  public p: number;
  constructor(@Inject(SearchService) private searchService: SearchService) {

  }
  ngOnInit() {
    this.getAllSearches();
  }
  getAllSearches() {
    this.searchService.getAllSearches()
      .subscribe((data: Search[]) => this.searches = data);
  }


}
