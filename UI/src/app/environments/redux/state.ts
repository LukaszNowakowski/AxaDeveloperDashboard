import { Injectable as states } from '@angular/core';
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
@states()
export class EnvironmentsState {
    @Action(actions.SetEnvironments)
    public setEnvironments(ctx: StateContext<model.EnvironmentsModel>, action: actions.SetEnvironments): void {
        const state = ctx.getState();
        ctx.setState({
            ...state,
            environments: action.Environments,
        });
    }
}
