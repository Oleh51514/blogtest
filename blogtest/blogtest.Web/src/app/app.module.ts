// external
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

// app
import { SharedModule } from './modules-shared/shared.module';
import { AppRoutingModule } from './app-routes.module';
// app > components
import { AppComponent } from './app.component';

import { ForbiddenComponent } from './modules/forbidden/forbidden.component';
import { HomeComponent } from './modules/home/home.component';
import { UnauthorizedComponent } from './modules/unauthorized/unauthorized.component';

import { AuthModule } from './modules/auth/auth.module';
import { OidcSecurityService } from './common/services/auth/oidc.security.service';

@NgModule({
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        AppRoutingModule,
        HttpModule,
        SharedModule.forRoot(),
        AuthModule.forRoot(),
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        ForbiddenComponent,
        UnauthorizedComponent
    ],
    bootstrap: [
        AppComponent
    ],
    providers: [
        OidcSecurityService
        // requestOptionsProvider
    ]
})

export class AppModule {
    constructor() {
    }
}