import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-pay-for-the-car',
  templateUrl: './pay-for-the-car.component.html',
  styleUrls: ['./pay-for-the-car.component.css']
})
export class PayForTheCarComponent {

  vin: string = '';
  data: any;

  constructor(private http: HttpClient, private toastr: ToastrService) { }

  updateData() {
    this.http.put<any>(`https://localhost:44347/api/Admin/pay-for-the-car/${this.vin}`, {}).subscribe({
      next: (response) => {
        this.data = response;
      },
      error: (error) => {
        this.toastr.error("Something went wrong! "+error.error);
      }
    });
  }

}
