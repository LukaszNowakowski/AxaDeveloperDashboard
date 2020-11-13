import { Injectable } from '@angular/core';
import { Action, State, StateContext } from '@ngxs/store';

import * as model from './model';
import * as actions from './actions';

@State<model.ApisUrls>({
    name: 'services',
    defaults: {
        environments: "",
        workItems: ""
    }
})
@Injectable()
export class ServicesState {
    @Action(actions.Actions.SetupApiUrls)
    public setupApiUrls(ctx: StateContext<model.ApisUrls>, action: actions.Actions.SetupApiUrls) {
        const state = ctx.getState();
        ctx.setState({
            ...state,
            environments: action.model.environments,
            workItems: action.model.workItems
        });
    }
}