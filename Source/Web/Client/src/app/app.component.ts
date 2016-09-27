import { Component }  from '@angular/core';
import { MapService } from '../services/map.service';

@Component({
    selector: 'sm-app',
    template: `
    <h1>Scotland's Mountains, coming soon</h1>
  `,
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    constructor(private mapService: MapService) { }

    ngAfterViewInit() {
        this.mapService.initializeMap();
    }
}
