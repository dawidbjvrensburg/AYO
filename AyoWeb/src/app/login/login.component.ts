import { Component, OnInit, NgModule } from '@angular/core';
import { Router } from '@angular/router';    
import { LoginService } from '../login.service';    
import { FormsModule ,FormBuilder, Validators } from '@angular/forms'; 
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  model : any={};    
  loginForm : any;
  errorMessage:string | undefined;    
  constructor(private formbulider: FormBuilder,private router:Router,private LoginService:LoginService, private toastr: ToastrService) { }   

  ngOnInit(){
    this.loginForm = this.formbulider.group({
      UserName: ['', [Validators.required]],
    });
    sessionStorage.removeItem('UserName');    
    sessionStorage.clear(); 
  }

  login(){    
    debugger;    
    if(this.model.UserName == undefined || this.model.Password == undefined)
    {
      this.toastr.error("Please specify a valid Username and Password", "Error");
    }
    else{
    this.LoginService.Login(this.model).subscribe(    
      data => {    
        debugger;    
        if(data == null)
        {
          this.errorMessage = "No User found with the credentials supplied. Please try again";
        }
        else{
          if(data.id > -1)    
          {       
            sessionStorage.setItem('UserName', data.userName);
            this.router.navigate(['Convert']);    
            debugger;    
          }    
          else{    
            this.errorMessage = data.Message;    
          }
        }    
      },    
      error => {    
        this.errorMessage = error.message;    
      });   
    } 
  };
  register(){
    this.router.navigate(['Register']);
  }
}
