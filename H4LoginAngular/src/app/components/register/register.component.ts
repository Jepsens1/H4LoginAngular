import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  userForm: FormGroup;

  constructor(private http: HttpClient, private forms: FormBuilder) {
    this.userForm  = this.forms.group({
      username: [''],
      password: [''],
    });
   }

  ngOnInit(): void {
  
  }
  onSubmit()
  {
    var formData: any = new FormData();
    formData.append("username", this.userForm.get('username'));
    formData.append("password", this.userForm.get('password'));
    this.http.post('https://localhost:7145/Signup', formData)
    .subscribe((respone)=> console.log(respone))
  }
}
