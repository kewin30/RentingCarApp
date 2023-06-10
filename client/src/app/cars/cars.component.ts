import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Cars } from '../_models/cars';
import { MemberService } from '../_services/member.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {

  cars: Cars[] = [];

  constructor(private http: HttpClient, private memberService: MemberService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getCars();
  }

  reserveCar(car: Cars) {
    this.memberService.reserveCars(car.vin).subscribe(
      () => {
        this.toastr.success('You have reserved: ' + car.model + ' from: ' + car.place);
        this.getCars();
      },
      (error) => {
        this.toastr.error('Something went wrong! ' + error);
      }
    );
  }

  getCars(): void {
    this.memberService.getCars().subscribe({
      next: (response) => {
        this.cars = response;
      },
      error: (error) => {
        console.log('Error occurred:', error);
      }
    });
  }
}
