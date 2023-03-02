import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CarGuessComponent } from './components/car-guess/car-guess.component';

const routes: Routes = [
  {path: '', component: CarGuessComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
