import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  //private apiUrl = 'http://localhost:5070/api/patients/register';
 private apiUrl ='https://patientmanagementsystem-1.onrender.com/api/patients/register';
 


  constructor(private http: HttpClient) {}

  registerPatient(data: any): Observable<{ message: string }> {
    return this.http.post<{ message: string }>(this.apiUrl, data);
  }
}
