import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormArray,
  FormBuilder,
  FormGroup,
  Validators,
  ReactiveFormsModule
} from '@angular/forms';
import { PatientService } from '../services/patient';

@Component({
  selector: 'app-patient-registration',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './patient-registration.html',
  styleUrls: ['./patient-registration.css']
})
export class PatientRegistrationComponent {

  patientForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private patientService: PatientService
  ) {
    this.patientForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      contactNumber: ['', Validators.required],
      insurances: this.fb.array([])
    });

    this.addInsurance();
  }

  get insurances(): FormArray {
    return this.patientForm.get('insurances') as FormArray;
  }

  // addInsurance() {
  //   this.insurances.controls.forEach(c =>
  //     c.get('isPrimary')?.setValue(false)
  //   );

  //   this.insurances.push(
  //     this.fb.group({
  //       policyNumber: ['', Validators.required],
  //       providerName: ['', Validators.required],
  //       isPrimary: [true]
  //     })
  //   );
  // }

  addInsurance() {
  this.insurances.push(
    this.fb.group({
      policyNumber: ['', Validators.required],
      providerName: ['', Validators.required],
      isPrimary: [this.insurances.length === 0] // first one only
    })
  );
}


  removeInsurance(index: number) {
    this.insurances.removeAt(index);
  }

  onPrimaryChange(selectedIndex: number) {
  this.insurances.controls.forEach((control, index) => {
    if (index !== selectedIndex) {
      control.get('isPrimary')?.setValue(false, { emitEvent: false });
    }
  });
}

  submit() {
    if (this.patientForm.invalid) {
      this.patientForm.markAllAsTouched();
      return;
    }

    if (this.insurances.length === 0) {
      alert('At least one insurance is required');
      return;
    }

    this.patientService.registerPatient(this.patientForm.value)
      .subscribe({
        next: () => {
          alert('Patient registered successfully');
          this.patientForm.reset();
          this.insurances.clear();
          this.addInsurance();
        },
        error: err => {
          console.error(err);
          alert('Error while saving patient');
        }
      });
  }
}