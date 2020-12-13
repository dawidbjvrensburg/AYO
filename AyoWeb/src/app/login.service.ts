import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';  
import {HttpHeaders} from '@angular/common/http';  
import { from, Observable } from 'rxjs';  
import { Register } from "../app/register";  
import { Response } from './response';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  Url :string;  
  //token : string;  
  header : any;  
  constructor(private http : HttpClient) {
    this.Url = 'https://localhost:44341/api/';  
    const headerSettings: {[name: string]: string | string[]; } = {};  
    this.header = new HttpHeaders(headerSettings); 
  }
  Login(model : any){
    debugger;  
     var a =this.Url+'User';  
    return this.http.post<any>(a, model, {headers: this.header}); 
  }
  CreateUser(model:Register)  
   {  
    debugger;  
     var a =this.Url+'Register';  
    return this.http.post<Response>(a, model, {headers: this.header});   
   }
}
