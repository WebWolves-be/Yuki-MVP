import {bootstrapApplication} from '@angular/platform-browser';
import {appConfig} from './app/app.config';
import {AppComponent} from './app/app.component';
import localeNlBe from '@angular/common/locales/nl-BE';
import {registerLocaleData} from "@angular/common";

registerLocaleData(localeNlBe);

bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));
