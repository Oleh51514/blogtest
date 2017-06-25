import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
// import { Configuration } from './app.constants';
import { OidcSecurityService } from './common/services/auth/oidc.security.service';
import { ForbiddenComponent } from './modules//forbidden/forbidden.component';
import { HomeComponent } from './modules/home/home.component';
import { UnauthorizedComponent } from './modules/unauthorized/unauthorized.component';




@Component({
    selector: 'my-app',
    templateUrl: 'app.component.html'
})

export class AppComponent implements OnInit {

    constructor(public securityService: OidcSecurityService) {
    }

    ngOnInit() {
        if (window.location.hash) {
            this.securityService.authorizedCallback();
        }
    }

    login() {
        console.log('start login');
        this.securityService.authorize();
    }

    refreshSession() {
        console.log('start refreshSession');
        this.securityService.authorize();
    }

    logout() {
        console.log('start logoff');
        this.securityService.logoff();
    }
}