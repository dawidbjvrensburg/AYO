import { Component, OnInit } from '@angular/core';
import { ConverterService } from '../converter.service';   
import {Register} from '../register';    
import {Observable} from 'rxjs';    
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';    
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Convert } from '../convert';

declare var jQuery : any;

@Component({
  selector: 'app-convert',
  templateUrl: './convert.component.html',
  styleUrls: ['./convert.component.css']
})
export class ConvertComponent implements OnInit {    
  model : Convert={IsImperial : "false", MetricUnit : "millimeter", ImperialUnit:"inches",UnitValue:""}; 
  convertForm: FormGroup = new FormGroup({});    
  message:string | undefined; 
  constructor(private toastr: ToastrService, private router: Router, private ConverterService:ConverterService) { }

  ngOnInit(){

    
    // Validation //
  }

  onFormSubmit(){
    const cvrt = this.model;    
    this.Convert(cvrt); 
  }

  Convert(convert:Convert)    
  {    
    if(this.model.UnitValue == "" || this.model.UnitValue == null)
    {
      this.toastr.error("Please provide a valid Unit Value", "Error");
    }
    else
    {
    this.ConverterService.Convert(convert).subscribe(    
    data =>    
    {    
      if(data.status == "Fail")
      {
        this.toastr.error('An error occured: '+ data.message, 'Error');
      }
      else
      {
         this.message = data.message;   
      }
      //this.convertForm.reset();    
    });    
  } 
}
}
