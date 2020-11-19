import { Injectable } from '@angular/core';
import { Action, State, StateContext } from '@ngxs/store';
import * as model from './model';
import * as actions from './actions';

@State<model.SecurityModel>({
  name: 'security',
  defaults: {
      IsAuthenticated: false,
      UserName: '',
      Token: ''
  }
})
@Injectable()
export class SecurityState {
    @Action(actions.AuthenticateUser)
    authenticateUser(ctx: StateContext<model.SecurityModel>, action: actions.AuthenticateUser): void {
        const state = ctx.getState();
        ctx.setState({
            ...state,
            IsAuthenticated: true,
            UserName: action.userName,
            Token: action.token
        });
    }

    @Action(actions.LogOffUser)
    logOffUser(ctx: StateContext<model.SecurityModel>): void {
        const state = ctx.getState();
        ctx.setState({
            ...state,
            IsAuthenticated: false,
            UserName: '',
            Token: ''
        });
    }
}
