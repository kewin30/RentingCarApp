import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { catchError, of, throwError } from 'rxjs';

@Component({
  selector: 'app-get-user',
  templateUrl: './get-user.component.html',
  styleUrls: ['./get-user.component.css']
})
export class GetUserComponent implements OnInit {

  userData: any;
  userId: number = 0;

  constructor(private http: HttpClient, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  getUserData() {
    this.http.get<any>(`https://localhost:44347/api/Admin/user/${this.userId}`).pipe(
      catchError(() => {
        this.toastr.error('User not found!');
        return of(null);
      })
    ).subscribe(
      (response) => {
        this.userData = response;
      }
    );
  }

}
