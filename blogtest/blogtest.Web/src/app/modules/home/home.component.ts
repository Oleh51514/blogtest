import { Component, OnInit } from '@angular/core';
import { OidcSecurityService } from '../../common/services/auth/oidc.security.service';

/* api-service */ import { PostApiService } from '../../common/services/api/entities/post.api.service';
@Component({
    selector: 'home',
    templateUrl: 'home.component.html'
})

export class HomeComponent implements OnInit {

    message: string;
    name = 'none';
    email = 'none';

    constructor (
        public securityService: OidcSecurityService,
        public postApiService: PostApiService
    ) {
        this.message = 'HomeComponent constructor';
        

    }

    ngOnInit() {
        if (this.securityService.isAuthorized) {
            let userData = this.securityService.getUserData();
            console.log(userData);
            //this.name = userData.name;
            //this.email = userData.email;
        }
        this.postApiService.getAll().do(
                data => {
                    console.log(data); 
                },
                error => { 
                    console.log(error); 
                 }
            );
    }
}
