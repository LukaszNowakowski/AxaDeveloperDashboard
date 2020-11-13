import { Injectable } from '@angular/core';
import { Action, State, StateContext } from '@ngxs/store';

import * as model from './model';
import * as actions from './actions';

@State<model.EnvironmentsModel>({
    name: 'environments',
    defaults: {
        environments: [
        ]
    }
})
@Injectable()
export class EnvironmentsState {
    @Action(actions.Actions.SetEnvironments)
    public setEnvironments(ctx: StateContext<model.EnvironmentsModel>, action: actions.Actions.SetEnvironments) {
        const state = ctx.getState();
        ctx.setState({
            ...state,
            environments: action.Environments,
        });
    }
}