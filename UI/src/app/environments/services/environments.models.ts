export interface Link {
    DisplayName: string;
    Url: string;
    Icon?: string;
}

export interface Environment {
    DisplayName: string;
    Links: Link[];
}

export interface FetchEnvironmentsRequest {
}

export interface FetchEnvironmentsResponse {
    Environments: Environment[];
}