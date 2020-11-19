import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Store } from '@ngxs/store';
import { Observable } from 'rxjs';

type CanActivateResult = boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree>;

@Injectable({
    providedIn: 'root'
  })
export class AuthGuard implements CanActivate {
    constructor(private store: Store, private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot): CanActivateResult {
        const isAuthenticated: boolean = this.store.selectSnapshot(state => state.security.IsAuthenticated);
        return isAuthenticated ? true : this.router.navigateByUrl('/login');
    }
}
