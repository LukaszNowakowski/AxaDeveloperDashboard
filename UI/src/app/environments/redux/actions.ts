import * as model from './model';

export namespace Actions {
    export class SetEnvironments {
        static readonly type: string = "[Environments] Set environments";
        constructor(public Environments: model.Environment[]) {}
    }
}