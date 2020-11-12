export interface Link {
    Id: number;
    DisplayName: string;
    Url: string;
    Icon?: string;
}

export interface Environment {
    Id: number;
    DisplayName: string;
    Links: Link[];
}

export interface FetchEnvironmentsRequest {
}

export interface FetchEnvironmentsResponse {
    Environments: Environment[];
}

export interface AddEnvironmentRequest {
    Environment: Environment;
}

export interface AddEnvironmentResponse {
    Created: boolean;
}