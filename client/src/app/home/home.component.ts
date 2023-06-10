import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  
  registerMode = false;
  informationMode = false;
  users: any;

  constructor() { }

  ngOnInit(): void {
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }
  informationToggle(){
    this.informationMode = !this.informationMode;
  }
  cancelinformationMode(event: boolean) {
    this.informationMode = event;
  } 

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  } 

}
