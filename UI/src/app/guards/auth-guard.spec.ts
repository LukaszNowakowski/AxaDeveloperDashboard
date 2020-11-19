import { AuthGuard } from './auth-guard';
import { Component } from '@angular/core';
import { TestBed } from '@angular/core/testing';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { NgxsModule, Store } from '@ngxs/store';

import * as state from '../security/redux/state';

const createMockRoute = (id: string) => {
  return {
    params: {
      id
    }
  } as any;
};

const createMockRouteState = () => null;

@Component({
  template: '<h1>LOGIN</h1>'
})
class LoginComponent {}

describe('AuthGuard', () => {
  let guard: AuthGuard;
  let store: Store;
  let router: Router;

  beforeEach(async () => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule.withRoutes([{ path: 'login', component: LoginComponent }]),
        NgxsModule.forRoot([state.SecurityState])
      ]
    });

    store = TestBed.inject(Store);
    router = TestBed.inject(Router);
    guard = new AuthGuard(store, router);
  });
  it('should create an instance', () => {
    expect(guard).toBeTruthy();
  });

  describe('canActivate', () => {
    it('returns true when user is authenticated', () => {
      store.reset({
        ...store.snapshot(),
        security: {
          IsAuthenticated: true
        }
      });
      const route = createMockRoute(null);
      const routeState = createMockRouteState();
      const res$ = guard.canActivate(route);
      expect(res$).toBeTrue();
    });

    it('redirects to login when user is not authenticated', (done) => {
      store.reset({
        ...store.snapshot(),
        security: {
          IsAuthenticated: false
        }
      });
      const route = createMockRoute(null);
      const routeState = createMockRouteState();
      const res$ = guard.canActivate(route);
      (res$ as Promise<boolean>).then(() => {
        expect(router.navigated).toBeTrue();
        expect(router.url).toBe('/login');
        done();
      });
    });
  });
});
