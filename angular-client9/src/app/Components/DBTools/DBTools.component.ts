import { Component, Inject } from '@angular/core';
import { DbtoolsService } from 'src/app/Services/dbtools.service';
import { ToastrService } from 'ngx-toastr';

function sleep(milliseconds) {
  const date = Date.now();
  let currentDate = null;
  do {
    currentDate = Date.now();
  } while (currentDate - date < milliseconds);
}

@Component({
  templateUrl: './DBTools.component.html',
  selector: 'app-dbtools'
})
export class DBToolsComponent {
  private simulateSalesResult: boolean;
  private SalePointStockDataResult: boolean;
  private simulateSearchesResult: boolean;
  public loading: boolean;
  public amountSales: string;
  public amountSearch: string;
  public monthSales: string;
  public yearSales: string;
  public porcessCount: number;
  public monthSearch: string;
  public yearSearch: string;
  public texto: string[];

  public zeroPad = (num, places) => String(num).padStart(places, '0');
  constructor(@Inject(DbtoolsService) private dbToolsService: DbtoolsService, private toastr: ToastrService ) {
    this.loading = false;
    this.amountSales = '100';
    this.amountSearch = '100';
    this.monthSales = '01';
    this.yearSales = '2020';
    this.monthSearch = '01';
    this.yearSearch = '2020';
    this.porcessCount = 0;
    this.texto = new Array<string>();
    this.addDataToConsole('Conectado a las Base de datos.');
  }
  addDataToConsole(data: string) {
    this.texto.push(data);
  }
  executeAllProccess() {
    const year = '2020';
    for (let month = 1; month <= 12; month++) {
      const monthstr = this.zeroPad(month, 2);
      this.dbToolsService.SimulateSales(this.amountSales, monthstr, year).subscribe((data: boolean) => {
        this.loading = false;
        this.simulateSalesResult = data;
        if (data) {
          this.toastr.success('Simulación de ventas completa', 'Your Choice S.A.!');
        }
      });
      sleep(3000);
    }
  }
  SimulateSales() {
    this.loading = true;
    this.dbToolsService.SimulateSales(this.amountSales, this.monthSales, this.yearSales).subscribe((data: boolean) => {
      this.loading = false;
      this.simulateSalesResult = data;
      if (data) {
        this.toastr.success('SimulateSales successfully', 'Products!');
      }
    });
  }
  CreateInitialData() {
    this.addDataToConsole('Creando datos iniciales....');
    this.loading = true;
    this.dbToolsService.CreateInitialData().subscribe((data: boolean) => {
      this.loading = false;
      if (data) {
        this.toastr.success('Datos creados correctamente', 'Your Choice S.A.!');
        this.addDataToConsole('Datos creados correctamente');
      }
      this.SalePointStockDataResult = data;
    });
  }
  DbInitialSalePointStockData() {
    this.addDataToConsole('Inicialización del stock iniciada');
    this.loading = true;
    this.dbToolsService.DbInitialSalePointStockData().subscribe((data: boolean) => {
      this.loading = false;
      this.addDataToConsole('Inicialización del stock finalizada');
      if (data) {
        this.toastr.success('Inicialización del stock finalizada', 'Products!');
      }
      this.SalePointStockDataResult = data;
    });
  }
  SimulateSearches() {
    this.loading = true;
    this.dbToolsService.SimulateFailSearches(this.amountSearch, this.monthSearch, this.yearSearch).subscribe((data: boolean) => {
      this.loading = false;
      this.simulateSearchesResult = data;
      if (data) {
        this.loading = false;
        this.toastr.success('La simulación de las intenciones de compra ha terminado', 'Products!');
        this.addDataToConsole('La simulación de las intenciones de compra ha terminado');
      }
    });
  }
  simulateExecuteProcess(count: string, month: string, year: string) {
    this.loading = true;
    this.addDataToConsole('Init Process');
    this.dbToolsService.SimulateExecuteProccess(count, month, year).subscribe((data: boolean) => {
      this.loading = false;
      this.simulateSearchesResult = data;
      if (data) {
        this.toastr.success('Finished Process', 'Products!');
        this.addDataToConsole('Finished Process');
        if (this.porcessCount <= 100) {
          this.porcessCount += 1;
          sleep(100);
          this.simulateExecuteProcess('1', '01', '2020');
        }
      }
    });
  }
  executeProcess() {
    this.simulateExecuteProcess('1', '01', '2020');
  }
}
