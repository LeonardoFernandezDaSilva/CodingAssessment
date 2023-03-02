import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { environment } from 'src/environments/environment';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CarGuessComponent } from './components/car-guess/car-guess.component';

@NgModule({
  declarations: [	
    AppComponent,
    CarGuessComponent
   ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    {
      provide: 'BASE_API_URL',
      useValue: environment.baseApiUrl
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
