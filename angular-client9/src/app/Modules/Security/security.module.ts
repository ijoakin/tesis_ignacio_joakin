import { NgModule } from '@angular/core';
import { UserComponent } from './Users/user.component';
import { SecurityService } from 'src/app/Services/security.service';
import { FormsModule } from '@angular/forms';
import { CommonModule} from '@angular/common';
import { NgxPaginationModule } from 'ngx-pagination';

@NgModule({
  declarations: [
    UserComponent
  ],
  providers: [
    SecurityService
  ],
  imports: [
    FormsModule,
    CommonModule,
    NgxPaginationModule
  ]
})
export class SecurityModule { }
