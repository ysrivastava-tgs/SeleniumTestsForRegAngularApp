import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  title = "Register"
  constructor(private formBuilder: FormBuilder) { }
  formSubmitted!:boolean;
  formControls!:any;
  registerForm!: FormGroup;
  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      name: ['', Validators.required],
     
      email: ['', [Validators.required, Validators.email]],
      password : ['', [Validators.required, Validators.minLength(6)]],
      cnf_password : ['', [Validators.required, Validators.minLength(6)]]
    });
    this.formControls = this.registerForm.controls;
  }
  handleFormSubmmit(event){
    // tslint:disable-next-line: no-unused-expression
    this.formSubmitted = true;
    if ( this.registerForm.invalid ){
      return;
    }
    else{
     const obj = this.registerForm.value;
     if(localStorage.getItem("email")==obj.email && localStorage.getItem("password")==obj.password)
     {
       document.getElementById("result").innerHTML = "Failed";
     }
     else{
       localStorage.setItem("email",obj.email);
       localStorage.setItem("password",obj.password);
       document.getElementById("result").innerHTML = "Registered";
     }
    }
 }
}
