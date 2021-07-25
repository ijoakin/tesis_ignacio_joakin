import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductComponent } from './Components/Product/product.component';
import { SalesComponent } from './Components/Sale/sales.component';
import { ServerComponent } from './Components/server/server.component';
import { SingupComponent } from './Components/auth/singup/singup.component';
import { SinginComponent } from './Components/auth/singin/singin.component';
import { AuthGuard } from './Guards/auth.guard';
import { UserComponent } from './Modules/Security/Users/user.component';
import { SalePointComponent } from './Components/Sale/salepoint.component';
import { DBToolsComponent } from './Components/DBTools/DBTools.component';
import { MLModelComponent } from './Components/Product/mlmodel.component';
import { SearchComponent } from './Components/Searches/search.component';
import { StockComponent } from './Components/stock/stock.component';
import { CountryComponent } from './Components/Country/country.component';
import { PredictionComponent } from 'src/app/Components/predictions/prediction.component';
import { GraphicsComponent } from 'src/app/Components/graphics/graphics.component';

const routes: Routes = [
  { path: 'products', component: ProductComponent },
  { path: 'sales', component: SalesComponent},
  { path: 'server', component: ServerComponent},
  { path: 'singup', component: SingupComponent},
  { path: 'singin', component: SinginComponent},
  { path: 'users', component: UserComponent },
  { path: 'salepoint', component: SalePointComponent },
  { path: 'dbtools', component: DBToolsComponent },
  { path: 'mlModel', component: MLModelComponent },
  { path: 'search', component: SearchComponent },
  { path: 'stock', component: StockComponent },
  { path: 'countries', component: CountryComponent },
  { path: 'predictions', component: PredictionComponent },
  { path: 'graphs', component: GraphicsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
