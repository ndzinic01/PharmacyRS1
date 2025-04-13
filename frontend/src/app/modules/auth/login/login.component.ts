import {Component} from '@angular/core';
import {Router} from '@angular/router';
import {AuthLoginEndpointService} from '../../../endpoints/auth-endpoints/auth-login-endpoint.service';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MyInputTextType} from '../../shared/my-reactive-forms/my-input-text/my-input-text.component';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  standalone: false,
})
export class LoginComponent {
  form: FormGroup;
  loginError: boolean = false; // Dodano
  protected readonly MyInputTextType = MyInputTextType;

  constructor(private fb: FormBuilder, private authLoginService: AuthLoginEndpointService, private router: Router) {

    this.form = this.fb.group({
      username: ['admin', [Validators.required, Validators.min(2), Validators.max(15)]],
      password: ['test', [Validators.required, Validators.min(2), Validators.max(30)]],
    });
  }

  onLogin(): void {
    if (this.form.invalid) return;

    this.authLoginService.handleAsync(this.form.value).subscribe({
      next: () => {
        const loginToken = this.authLoginService.myAuthService.getLoginToken();

        if (loginToken?.myAuthInfo?.isAdmin) {
          this.router.navigate(['/admin']);
        } else if (loginToken?.myAuthInfo?.isPharmacist) {
          this.router.navigate(['/pharmacist']);
        } else if (loginToken?.myAuthInfo?.isCustomer) {
          this.router.navigate(['/public']);
        } else {
          this.router.navigate(['/unauthorized']); // fallback u slučaju da ništa ne odgovara
        }
      },
      error: (err) => {
        console.error('Login failed:', err);
        this.form.setErrors({loginFailed: true});
      }
    });
  }

}
