import * as model from './model';

export namespace Actions {
    export class SetupApiUrls {
        static readonly type: string = "[Services] Setup urls";
        constructor(public model: model.ApisUrls) { }
    }
}