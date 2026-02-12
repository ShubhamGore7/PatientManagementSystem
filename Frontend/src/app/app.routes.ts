import { Routes } from '@angular/router';
import { PatientRegistrationComponent } from './patient-registration/patient-registration';

export const routes: Routes = [
  { path: '', redirectTo: 'register', pathMatch: 'full' },   // 👈 Default route
  { path: 'register', component: PatientRegistrationComponent }
];
