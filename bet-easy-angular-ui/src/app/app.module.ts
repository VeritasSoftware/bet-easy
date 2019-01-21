import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';

import { AppConfigModule } from './app-config.module';
import { HomeComponent } from './components/home/home.component';
import { BetEasyService } from './services/bet-easy-service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    AppConfigModule
  ],
  providers: [BetEasyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
