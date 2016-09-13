///<reference path="../typings/index.d.ts"/> //https://stackoverflow.com/questions/33332394/angular-2-typescript-cant-find-names
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { AppModule } from './app/app.module';
if (process.env.ENV === 'production') {
  enableProdMode();
}
platformBrowserDynamic().bootstrapModule(AppModule);
