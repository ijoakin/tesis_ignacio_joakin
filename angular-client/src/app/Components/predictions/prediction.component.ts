import { Component, Inject, OnInit } from '@angular/core';
import { Prediction } from 'src/app/Model/Prediction';
import { PredictionService } from 'src/app/Services/prediction.service';

@Component({
  templateUrl: './prediction.component.html',
  selector: 'app-prediction'
})
export class PredictionComponent implements OnInit {
  public predictions: Prediction[];
  public p: number;
  public result: Boolean;

  constructor(@Inject(PredictionService) private predictionService: PredictionService) {

  }

  ngOnInit(): void {
    this.getAllPredictions();
  }

  public getAllPredictions() {
    this.predictionService.GetAllPredictions()
        .subscribe((data: Prediction[]) => this.predictions = data);

    /*this.description = 'Ignacio Joakin';
    console.log(this.description);*/

  }
  public ApplyPrediction(id: number): void {

  }
  public ApplyAllPredictions(): void {
    this.predictionService.applyPredictions()
      .subscribe((data: boolean) => {
        this.result = data;
        if (this.result) {
          this.getAllPredictions();
        }
      });

  }
}

