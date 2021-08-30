import { Sale } from './Sale';

export class ServerSideSales {

    data: Sale[];
    count: number;

    constructor(data: Sale[], count: number) {
        this.data = data;
        this.count = count;
    }
}
