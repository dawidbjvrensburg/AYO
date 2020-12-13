import { Component, OnInit } from '@angular/core';
import { ConverterService } from '../converter.service';   
import {Register} from '../register';    
import {Observable} from 'rxjs';    
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';    
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { Convert } from '../convert';
//import * as $ from 'jquery';

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

    //$(document).ready(function(){
      // $('#cmbType').change(function(e){
      //   if($('#cmbType').val() == "length")
      //   {
      //     $('#divLengthPanel').show();
      //     $('#divTemperaturePanel').hide();
      //   }
      //   else{
      //     $('#divLengthPanel').hide();
      //     $('#divTemperaturePanel').show();
      //   }
      // })


      //  $('#cmbMetric').change(function(e){
      //    if($('#cmbMetric').val() == 'celcius')
      //    {
      //      $('#cmbImperial').val('farenheit');
      //      //$('#cmbImperial').change();
      //      //$('#cmbMetric').val('celcius');
      //    }
      //  })

      //  $('#cmbImperial').change(function(e){
      //    if($('#cmbImperial').val() == 'farenheit')
      //    {
      //      $('#cmbMetric').val('celcius');
      //      //$('#cmbImperial').val('farenheit');
      //    }
      //  })
      
    //});
    // Validation //

    
  }

  changeTypeImperial(){
    const cvrt = this.model;
    if(this.model.ImperialUnit == "farenheit")
    {
      this.model.MetricUnit = "celcius";
    }
  }

  changeTypeMetric(){
    const cvrt = this.model;
    if(this.model.MetricUnit == "celcius")
    {
      this.model.ImperialUnit = "farenheit";
    }
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
      if(this.model.MetricUnit == "celcius" && this.model.ImperialUnit != "farenheit")
      {
        this.toastr.warning("Please ensure that both Metric and Imperial Unit is of either Distance or Temperature type");
        return;
      }
      else if(this.model.ImperialUnit == "farenheit" && this.model.MetricUnit != "celcius")
      {
        this.toastr.warning("Please ensure that both Metric and Imperial Unit is of either Distance or Temperature type");
        return;
      }
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
