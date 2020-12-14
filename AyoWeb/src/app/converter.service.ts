import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';  
import {HttpHeaders} from '@angular/common/http';  
import { from, Observable } from 'rxjs';  
import { Register } from "../app/register";  
import { Response } from './response';
import { Convert } from './convert';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ConverterService {
  Url :string;  
  //token : string;  
  header : any;  
  constructor(private http : HttpClient) {
    this.Url = environment.apiEndpoint;  
    const headerSettings: {[name: string]: string | string[]; } = {};  
    this.header = new HttpHeaders(headerSettings); 
  }
  Convert(model:Convert)  
   {  
    debugger;  
     var a =this.Url+'Convert';  
    return this.http.post<Response>(a, model, {headers: this.header});   
   }
}
