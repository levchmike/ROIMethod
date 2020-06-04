import { Component } from '@angular/core'
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { select, Store } from '@ngrx/store'
import * as Reducers from 'src/app/store/reducers'
import { AuthService } from 'src/app/services/firebase.auth.service'

@Component({
  selector: 'cui-system-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  form: FormGroup
  logo: String
  authProvider: string = 'firebase'

  constructor(private fb: FormBuilder, public authService: AuthService, private store: Store<any>) {
    this.form = fb.group({
      email: ['admin@mediatec.org', [Validators.required, Validators.minLength(4)]],
      password: ['cleanui', [Validators.required]],
    })
    this.store.pipe(select(Reducers.getSettings)).subscribe(state => {
      this.logo = state.logo
    })
  }

  get email() {
    return this.form.controls.email
  }
  get password() {
    return this.form.controls.password
  }

  submitForm(): void {
    this.email.markAsDirty()
    this.email.updateValueAndValidity()
    this.password.markAsDirty()
    this.password.updateValueAndValidity()
    if (this.email.invalid || this.password.invalid) {
      return
    }
    this.authService.SignIn(this.email.value, this.password.value)
  }
}
