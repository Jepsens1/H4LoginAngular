import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup } from "@angular/forms";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  form: FormGroup;

  constructor(private http: HttpClient, private formbuilder: FormBuilder) {
    this.form = this.formbuilder.group({
      username: [''],
      password: [''],
    });
   }

  ngOnInit(): void {
  }
  onSubmit() {
    var formdata: any = new FormData();
    formdata.append('username', this.form.get('username')!.value);
    formdata.append('password', this.form.get('password')!.value);
    this.http.post('api/Login/Signup', formdata)
    .subscribe((respone)=> console.log(respone))
  }
  
}
