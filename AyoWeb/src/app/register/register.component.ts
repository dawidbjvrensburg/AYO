import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login.service';    
import {Register} from '../register';    
import {Observable} from 'rxjs';    
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';    
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  data = false;    
  model : Register={Email:"",Name:"", Password:"",UserName:""}; 
  userForm: FormGroup = new FormGroup({});    
  message:string | undefined; 
  constructor(private formbulider: FormBuilder,private loginService:LoginService, private toastr: ToastrService, private router: Router) { 
    this.userForm = formbulider.group({    
      UserName: ['', [Validators.required]],    
      Name: ['', [Validators.required]],    
      Password: ['', [Validators.required]],    
      Email: ['', [Validators.required]],       
    }) 
  }

  onFormSubmit(){
    const user = this.model;    
    this.CreateUser(user); 
  }
  CreateUser(register:Register)    
  {    
    if(this.model.UserName == "" || this.model.Password == "")
    {
      this.toastr.error("Please provide at-least a Username and Password", "Error");
    }
    else{
      this.loginService.CreateUser(register).subscribe(    
      data =>    
      {    
        if(data.status == "Fail")
        {
          this.toastr.error('An error occured: '+ data.message, 'Error');
        }
        else
        {
          this.router.navigate(['']).then(() =>{
            this.toastr.success('The new user was saved', 'Success');
          });    
        }
        this.userForm.reset();    
      }); 
    }   
  } 
}
