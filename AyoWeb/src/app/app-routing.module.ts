import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
//import { DashboardComponent } from './dashboard/dashboard.component';    
import { LoginComponent } from './login/login.component';    
import { RegisterComponent } from './register/register.component';
import { ConvertComponent } from './convert/convert.component';

export const routes: Routes = [    
  {    
    path: '',    
    redirectTo: 'login',    
    pathMatch: 'full',    
  },
  {    
    path: 'login',    
    component: LoginComponent,    
    data: {    
      title: 'Login Page'    
    }    
  }, 
  {    
    path: 'Register',    
    component: RegisterComponent
  },
  {    
    path: 'Convert',    
    component: ConvertComponent
  },     
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
