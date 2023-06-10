import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-information-panel',
  templateUrl: './information-panel.component.html',
  styleUrls: ['./information-panel.component.css']
})
export class InformationPanelComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  constructor() { }

  ngOnInit(): void {
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

}
