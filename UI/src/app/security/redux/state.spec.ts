import * as models from './model';
import * as actions from './actions';
import * as securityState from './state';
import { NgxsModule, Store } from '@ngxs/store';
import { TestBed } from '@angular/core/testing';

describe('Security state', () => {
    let store: Store;
    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [
                NgxsModule.forRoot([securityState.SecurityState])
            ]
        });

        store = TestBed.inject(Store);
        store.reset({
            ...store.snapshot(),
            security: { IsAuthenticated: false, UserName: '', Token: '' } as models.SecurityModel
        });
    });

    describe('authenticateUser', () => {
        it('sets model properties correctly', () => {
            const expectedUserName = 'ExampleUserName';
            const expectedToken = 'SomeSecurityToken';
            const action: actions.AuthenticateUser = new actions.AuthenticateUser(expectedUserName, expectedToken);
            store.dispatch(action);
            const model = store.selectSnapshot<models.SecurityModel>(state => state.security);
            expect(model).toBeTruthy();
            expect(model.IsAuthenticated).toBeTrue();
            expect(model.UserName).toBe(expectedUserName);
            expect(model.Token).toBe(expectedToken);
        });
    });

    describe('logOff', () => {
        beforeEach(() => {
            store.reset({
                ...store.snapshot(),
                security: { IsAuthenticated: true, UserName: 'SomeUser', Token: 'Valid token' } as models.SecurityModel
            });
        });

        it('sets model properties correctly', () => {
            const action: actions.LogOffUser = new actions.LogOffUser();
            store.dispatch(action);
            const model = store.selectSnapshot<models.SecurityModel>(state => state.security);
            expect(model).toBeTruthy();
            expect(model.IsAuthenticated).toBeFalse();
            expect(model.UserName).toBe('');
            expect(model.Token).toBe('');
        });
    });
});
