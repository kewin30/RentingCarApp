import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FileUploader } from 'ng2-file-upload';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-car-management',
  templateUrl: './add-car-management.component.html',
  styleUrls: ['./add-car-management.component.css']
})
export class AddCarManagementComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  carForm: FormGroup = new FormGroup({});
  validationErrors: string[] | undefined;
  hasBaseDropZoneOver = false;
  uploader: FileUploader | undefined;
  baseUrl = environment.apiUrl;
  user: User | undefined;

  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private accountService: AccountService,
    private http: HttpClient
  ) {
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: (user) => {
        if (user) this.user = user;
      }
    });
  }

  fileOverBase(e: any) {
    this.hasBaseDropZoneOver = e;
  }

  ngOnInit(): void {
    this.initializeForm();
    this.initializeUploader();
  }
  parseBoolean(value: any): boolean | null {
    if (typeof value === 'boolean') {
      return value;
    } else if (typeof value === 'string') {
      if (value.toLowerCase() === 'true') {
        return true;
      } else if (value.toLowerCase() === 'false') {
        return false;
      }
    }
    return null;
  }
  initializeForm() {
    this.carForm = this.fb.group({
      Vin: ['', [Validators.required, Validators.minLength(4)]],
      GpsEnabled: ['True', Validators.required],
      Plate: ['', [Validators.required, Validators.maxLength(20)]],
      Model: ['', Validators.required],
      CarYear: ['', [Validators.required, Validators.min(2018), Validators.max(2023)]],
      Color: ['', Validators.required],
      Weight: ['', Validators.required],
      PrizeForDay: ['', Validators.required],
      PrizeForWeek: ['', Validators.required],
      Place: ['', Validators.required],
    });
  }

  addNewCar() {
    console.log("Add new car!");
    const gpsEnabled = this.carForm.value.GpsEnabled;
    const gpsEnabledBoolean = this.parseBoolean(gpsEnabled);
    if (gpsEnabledBoolean === null) {
      this.toastr.error("Didn't pick proper value for gps! ");
      return;
    }
    const place = this.carForm.value.Place;
    if (gpsEnabled !== 'True' && gpsEnabled !== 'False') {
      this.toastr.error("Didn't pick proper value for gps! ");
      return;
    }
    if (
      place !== 'Palma Airport' &&
      place !== 'Palma City Center' &&
      place !== 'Alcudia' &&
      place !== 'Manacor'
    ) {
      this.toastr.error("Didn't pick the proper value for place! ");
      return;
    }
    const values = { ...this.carForm.value, GpsEnabled: gpsEnabledBoolean };
    console.log("Test!");
    this.sendCarData(values);
  }

  sendCarData(values: any) {
    const dto = { ...values };
    const formData = new FormData();
    formData.append('dto', JSON.stringify(dto));

    const fileItem = this.uploader?.queue[0];
    if (fileItem) {
      const file: File = fileItem._file;
      formData.append('file', file, file.name);
    }

    this.http
      .post(`${this.baseUrl}Admin/add-car-with-photo`, formData, { responseType: 'text' })
      .subscribe({
        next: (response: any) => {
          const successMessage = response || 'Car has been added successfully';
          this.toastr.success(successMessage);
        },
        error: (error: any) => {
          console.log(error);
          this.toastr.error('An error occurred while adding the car');
        },
        complete: () => {
          console.log('complete');
        }
      });
  }


  cancel() {
    this.cancelRegister.emit(false);
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'Admin/add-car-with-photo',
      authToken: 'Bearer ' + this.user?.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    };

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const photo = JSON.parse(response);
        const photoId = photo?.id;
        this.sendCarData(this.carForm.value);
      }
    };
  }
}
