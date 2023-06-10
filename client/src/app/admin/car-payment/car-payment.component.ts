import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-car-payment',
  templateUrl: './car-payment.component.html',
  styleUrls: ['./car-payment.component.css']
})
export class CarPaymentComponent {

  vin: string = '';
  paymentData: any;

  constructor(private http: HttpClient, private toastr: ToastrService) {}

  getPaymentData() {
    this.http.get<any>(`https://localhost:44347/api/Admin/payment/${this.vin}`).subscribe({
      next: (response) => {
        this.paymentData = response;
      },
      error: (error) => {
        this.toastr.error("Something went wrong! "+error.error);
      }
    });
  }

}
