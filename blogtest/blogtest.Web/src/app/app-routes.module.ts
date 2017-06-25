import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { ForbiddenComponent } from './modules/forbidden/forbidden.component';
import { HomeComponent } from './modules/home/home.component';
import { UnauthorizedComponent } from './modules/unauthorized/unauthorized.component';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'home', component: HomeComponent },
    { path: 'Forbidden', component: ForbiddenComponent },
    { path: 'Unauthorized', component: UnauthorizedComponent }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ],
  providers: [
  ]
})
export class AppRoutingModule {
}
