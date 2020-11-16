export interface Link {
    Id: number;
    DisplayName: string;
    Url: string;
    Icon?: string;
    Order: number;
}

export interface Environment {
    Id: number;
    DisplayName: string;
    Links: Link[];
    Order: number;
}

export interface AddEnvironmentRequest {
    Environment: Environment;
}

export interface AddEnvironmentResponse {
    Created: boolean;
}
