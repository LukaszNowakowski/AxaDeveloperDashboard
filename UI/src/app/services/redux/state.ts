import { Injectable } from '@angular/core';
import { Action, State, StateContext } from '@ngxs/store';

import * as model from './model';
import * as actions from './actions';

@State<model.ServicesModel>({
    name: 'services',
    defaults: {
        environments: '',
        workItems: '',
        security: ''
    }
})
@Injectable()
export class ServicesState {
    @Action(actions.SetupApiUrls)
    public setupApiUrls(ctx: StateContext<model.ServicesModel>, action: actions.SetupApiUrls): void {
        const state = ctx.getState();
        console.log(action);
        ctx.setState({
            ...state,
            environments: action.model.environments,
            workItems: action.model.workItems,
            security: action.model.security
        });
    }
}
