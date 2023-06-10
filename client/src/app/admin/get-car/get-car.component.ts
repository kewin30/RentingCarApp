import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-get-car',
  templateUrl: './get-car.component.html',
  styleUrls: ['./get-car.component.css']
})
export class GetCarComponent implements OnInit {

  vin: string = '';
  carData: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  getCarByVin() {
    if (this.vin) {
      this.http.get<any>(`https://localhost:44347/api/Admin/${this.vin}`).subscribe(
        (response) => {
          this.carData = response;
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }

}
