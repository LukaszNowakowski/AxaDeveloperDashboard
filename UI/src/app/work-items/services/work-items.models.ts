export interface CreateProductionLogUrlRequest {
    ErrorId: number;
}

export interface CreateProductionLogUrlResponse {
    Success: boolean;
    Url: string;
    Error: string;
}