import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PortalComponent } from 'src/app/Components/Portal/portal.component';
import { ProductService } from 'src/app/Services/product.service';
import { HttpClientModule } from '@angular/common/http';
import { CountryService } from 'src/app/Services/country.service';
import { FormsModule } from '@angular/forms';
import { DbtoolsService } from 'src/app/Services/dbtools.service';
import { DistanceService } from 'src/app/Services/distances.service';
import { GraphService } from 'src/app/Services/graph.service';
import { LoginService } from 'src/app/Services/login.service';
import { PredictionService } from 'src/app/Services/prediction.service';
import { SaleService } from 'src/app/Services/sale.service';
import { SalePointService } from 'src/app/Services/salepoint.service';
import { SearchService } from 'src/app/Services/search.service';
import { StockService } from 'src/app/Services/stock.service';

@NgModule({
  declarations: [
    AppComponent,
    PortalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
   ProductService,
    SaleService,
    LoginService,
    DbtoolsService,
    SearchService,
    StockService,
    SalePointService,
    CountryService,
    PredictionService,
    GraphService,
    DistanceService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
