export class AuthenticateUser {
    static readonly type = '[Security] Authenticate user';
    constructor(public userName: string, public token: string) { }
}

export class LogOffUser {
    static readonly type = '[Security] Log off user';
}
