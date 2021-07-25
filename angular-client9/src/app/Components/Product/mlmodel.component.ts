import { Component, Inject, OnInit } from '@angular/core';
import { MLModel } from 'src/app/Model/MLModel';
import { DbtoolsService } from 'src/app/Services/dbtools.service';

@Component({
  selector: 'mlmodel-app',
  templateUrl: './mlmodel.component.html'
})
export class MLModelComponent implements OnInit {
  public arrMLModel: MLModel[];
  public loading: boolean;
  public p: number;

  constructor(@Inject(DbtoolsService) private dbtoolsService: DbtoolsService) {

  }

  public ngOnInit() {
    this.getMLMolde();
  }

  public getMLMolde() {
    this.loading = true;
    this.dbtoolsService.getMLModel().subscribe((data: MLModel[]) => {
      this.loading = false;
      this.arrMLModel = data;
      if (data) {
        // this.toastr.success('SimulateSales successfully', 'Products!');
      }
    });
  }
}
