import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-user-before',
  templateUrl: './user-before.component.html',
  styleUrls: ['./user-before.component.css']
})
export class UserBeforeComponent{

  vin: string = '';
  userData: any;

  constructor(private http: HttpClient, private toastr: ToastrService) {}

  getUserData() {
    this.http.get<any>(`https://localhost:44347/api/Admin/userBefore/${this.vin}`).subscribe({
      next: (response) => {
        this.userData = response;
      },
      error: (error) => {
        this.toastr.error("Something went wrong! "+error.error);
      }
    });
  }

}
