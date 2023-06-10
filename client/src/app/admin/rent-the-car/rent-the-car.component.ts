import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-rent-the-car',
  templateUrl: './rent-the-car.component.html',
  styleUrls: ['./rent-the-car.component.css']
})
export class RentTheCarComponent implements OnInit {
  
  registerForm: FormGroup = new FormGroup({});
  data: any;

  constructor(private fb: FormBuilder,private http: HttpClient, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.initializeForm();
  }
  private getDateOnly(dob: string | undefined){
    if(!dob) return;
    let theDob = new Date(dob);
    return new Date(theDob.setMinutes(theDob.getMinutes()- theDob.getTimezoneOffset())).toISOString().slice(0,10);
  }
  initializeForm(){
    this.registerForm = this.fb.group({
      vin: ['', Validators.required],
      rentedFrom: ['', Validators.required],
      rentedTo: ['', Validators.required],
    });
  }
  rentTheCar(){
    const dateFrom = this.getDateOnly(this.registerForm.controls['rentedFrom'].value);
    const dateTo = this.getDateOnly(this.registerForm.controls['rentedTo'].value);
    const values = {...this.registerForm.value, rentedFrom: dateFrom, rentedTo:dateTo};

    this.http.put<any>(`https://localhost:44347/api/Admin/rent-the-car`, values).subscribe({
      next: (response)=>{
        this.data = response;
      },
      error: (error)=>{
        this.toastr.error("Something went wrong! "+error.error);
      }
    });
  }

}
