import * as models from './model';

export class SetupApiUrls {
    static readonly type: string = '[Services] Setup urls';
    constructor(public model: models.ServicesModel) { }
}
