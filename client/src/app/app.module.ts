import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LogInComponent } from './components/log-in/log-in.component';
import { RegisterComponent } from './components/register/register.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from './angular-material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule } from '@angular/common/http';
import { VerificationComponent } from './components/verification/verification.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PhotoComponent } from './components/photo/photo.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AddPhotoComponent } from './components/add-photo/add-photo.component';
import { NgpImagePickerModule } from 'ngp-image-picker';

export function tokenGetter() {
  return localStorage.getItem("authToken");
}
@NgModule({
  declarations: [AppComponent, LogInComponent, RegisterComponent, VerificationComponent, DashboardComponent, PhotoComponent, AddPhotoComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AngularMaterialModule,
    FormsModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    HttpClientModule,
    NgpImagePickerModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:4200']
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }
