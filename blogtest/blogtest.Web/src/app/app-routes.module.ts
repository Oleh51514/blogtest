import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ForbiddenComponent } from './modules/forbidden/forbidden.component';
import { HomeComponent } from './modules/home/home.component';
import { UnauthorizedComponent } from './modules/unauthorized/unauthorized.component';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    // lazy-loading
    // { path: 'workspace/:tenant', loadChildren: './modules-layouts/workspace/workspace.module#WorkspaceModule' },
    // { path: '', loadChildren: './modules-layouts/welcome/welcome.module#WelcomeModule' },
    // { path: 'login', loadChildren: './modules/account/login/login.module#LoginModule' },
    // { path: 'about', loadChildren: './modules/about/about.module#AboutModule' },
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
