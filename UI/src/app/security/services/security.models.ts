export interface CreateUserRequest {
    UserName: string;
    DisplayName: string;
    Email: string;
    Password: string;
}

export interface CreateUserResponse {
    Created: boolean;
}

export interface VerifyCredentialsRequest {
    UserName: string;
    Password: string;
}

export interface VerifyCredentialsResponse {
    CredentialsValid: boolean;
}