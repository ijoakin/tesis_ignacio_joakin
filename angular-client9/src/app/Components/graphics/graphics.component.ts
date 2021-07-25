import { Inject } from "@angular/core";
import { Component } from "@angular/core";
import { Graph } from "src/app/Model/Graph";
import { GraphService } from "src/app/Services/graph.service";

@Component({
  selector: 'app-grp',
  templateUrl: './graphics.component.html'
})
export class GraphicsComponent {
  public p: number;

  public graphList: Graph[];
  public graph = {
              data: [
                  { x: [], y: [], type: 'scatter', mode: 'lines+points', marker: {color: 'red'} },
                  { x: [], y: [], type: 'bar' },
              ],
              layout: {width: 800, height: 500, title: 'Ventas vs Ventas no realizadas'}
          };

  public graphVentas = {
              data: [
                  { x: [], y: [], type: 'scatter', mode: 'lines+points', marker: {color: 'red'} },
                  { x: [], y: [], type: 'bar' },
              ],
              layout: {width: 800, height: 500, title: 'Ventas'}
          };



  constructor(@Inject(GraphService) private graphService: GraphService) {

  }

  public GetDataToGraph() {
    this.graphService.GetDataToGraph()
      .subscribe((data: Graph[]) => {
        this.graphList = data;

        var datax = [];
        var datay = [];

        var dataxFail = [];
        var datayFail = [];

        for(var i=0;i<this.graphList.length; i++){

          if (this.graphList[i].success) {
            datax.push(this.graphList[i].year + "-" + this.graphList[i].month);
            datay.push(this.graphList[i].amount);
          }
          if (!this.graphList[i].success) {
            dataxFail.push(this.graphList[i].year + "-" + this.graphList[i].month);
            datayFail.push(this.graphList[i].amount);
          }

        }

        this.graph = {
                data: [
                    { x: datax, y: datay, type: 'bar', mode: 'marker', marker: {color: 'green'} },
                    { x: dataxFail, y: datayFail, type: 'bar', mode: 'marker', marker: {color: 'red'} },
                ],
                layout: {width: 1200, height: 500, title: 'Ventas vs Ventas no realizadas'}
            };

        this.graphVentas = {
                data: [
                    { x: datax, y: datay, type: 'bar', mode: 'marker', marker: {color: 'green'} }
                ],
                layout: {width: 1200, height: 500, title: 'Ventas'}
            };
      })
  }
}
