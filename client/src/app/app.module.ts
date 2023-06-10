import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { HomeComponent } from './home/home.component';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HasRoleDirective } from './_directives/has-role.directive';
import { CarsComponent } from './cars/cars.component';
import { InformationPanelComponent } from './information-panel/information-panel.component';
import { RegisterComponent } from './register/register.component';
import { ToastrModule } from 'ngx-toastr';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { DatePickerComponent } from './_forms/date-picker/date-picker.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { AddCarManagementComponent } from './admin/add-car-management/add-car-management.component';
import { FileUploadModule } from 'ng2-file-upload';
import { GetUserComponent } from './admin/get-user/get-user.component';
import { GetCarComponent } from './admin/get-car/get-car.component';
import { CarPaymentComponent } from './admin/car-payment/car-payment.component';
import { UserBeforeComponent } from './admin/user-before/user-before.component';
import { PayForTheCarComponent } from './admin/pay-for-the-car/pay-for-the-car.component';
import { RentTheCarComponent } from './admin/rent-the-car/rent-the-car.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    NotFoundComponent,
    ServerErrorComponent,
    HomeComponent,
    AdminPanelComponent,
    HasRoleDirective,
    CarsComponent,
    InformationPanelComponent,
    RegisterComponent,
    TextInputComponent,
    DatePickerComponent,
    AddCarManagementComponent,
    GetUserComponent,
    GetCarComponent,
    CarPaymentComponent,
    UserBeforeComponent,
    PayForTheCarComponent,
    RentTheCarComponent
  ],
  imports: [
    BsDropdownModule,
    FileUploadModule,
    TabsModule.forRoot(),
    BrowserAnimationsModule,
    BrowserModule,
    ReactiveFormsModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BsDatepickerModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
