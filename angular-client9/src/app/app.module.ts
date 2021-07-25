import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
// My modules
import { SecurityModule } from './Modules/Security/security.module';

// third party modules
import {NgxPaginationModule} from 'ngx-pagination';
import { ToastrModule } from 'ngx-toastr';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome'

// Services
import { ProductService } from './Services/product.service';
import { SaleService } from './Services/sale.service';
import { LoginService } from './Services/login.service';
import { DbtoolsService } from './Services/dbtools.service';
import { SearchService } from './Services/search.service';
import { StockService } from './Services/stock.service';
import { SalePointService } from './Services/salepoint.service';
import { CountryService } from './Services/country.service';
import { PredictionService } from 'src/app/Services/prediction.service';
import { GraphService } from 'src/app/Services/graph.service';
import { DistanceService } from 'src/app/Services/distances.service';

// Components
import { AppComponent } from './app.component';
import { MenuComponent } from './Components/Menu/menu.component';
import { ProductComponent } from './Components/Product/product.component';
import { SalesComponent } from './Components/Sale/sales.component';
import { ServerComponent } from './Components/server/server.component';
import { SingupComponent } from './Components/auth/singup/singup.component';
import { SinginComponent } from './Components/auth/singin/singin.component';
import { ModalComponent } from './Components/Common/modal.component';
import { RoleComponent } from './Components/Role/role.component';
import { SalePointComponent } from './Components/Sale/salepoint.component';
import { SearchComponent } from './Components/Searches/search.component';
import { DBToolsComponent } from './Components/DBTools/DBTools.component';
import { MLModelComponent } from './Components/Product/mlmodel.component';
import { StockComponent } from './Components/stock/stock.component';
import { GraphicsComponent } from './Components/graphics/graphics.component';
import { CountryComponent } from './Components/Country/country.component';
import { PredictionComponent } from './Components/predictions/prediction.component';

import { CommonModule } from '@angular/common';
import * as PlotlyJS from 'plotly.js/dist/plotly.js';
import { PlotlyModule } from 'angular-plotly.js';
import { DistanceComponent } from 'src/app/Components/predictions/distance.component';


PlotlyModule.plotlyjs = PlotlyJS;
@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    ProductComponent,
    SalesComponent,
    ServerComponent,
    SingupComponent,
    SinginComponent,
    ModalComponent,
    RoleComponent,
    SalePointComponent,
    SearchComponent,
    DBToolsComponent,
    MLModelComponent,
    StockComponent,
    GraphicsComponent,
    CountryComponent,
    PredictionComponent,
    DistanceComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgxPaginationModule,
    ToastrModule.forRoot(),
    SecurityModule,
    FontAwesomeModule,
    CommonModule,
    PlotlyModule
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
