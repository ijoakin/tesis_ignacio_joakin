import { Inject } from "@angular/core";
import { Component } from "@angular/core";
import { Graph } from "src/app/Model/Graph";
import { GraphService } from "src/app/Services/graph.service";

@Component({
  selector: 'app-grp',
  templateUrl: './graphics.component.html'
})
export class GraphicsComponent {

  public graphList: Graph[];

    public graph = {
        data: [
            { x: [1, 2, 3], y: [2, 6, 3], type: 'scatter', mode: 'lines+points', marker: {color: 'red'} },
            { x: [1, 2, 3], y: [2, 5, 3], type: 'bar' },
        ],
        layout: {width: 320, height: 240, title: 'A Fancy Plot'}
    };

  constructor(@Inject(GraphService) private graphService: GraphService) {

  }

  public GetDataToGraph() {
    this.graphService.GetDataToGraph().subscribe((data: Graph[]) => this.graphList = data)
  }

}
