import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { HttpModule }    from '@angular/http';

import { AppComponent } from './app.component';
import { MapService }   from '../services/map.service';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule
    ],
    declarations: [
        AppComponent
    ],
    providers: [MapService],
    bootstrap: [AppComponent]
})

export class AppModule {
}
