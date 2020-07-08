export interface TestResults {
    ran: number;
    passed: number;
    failed: number;
    passRate: number;
}

export interface EnvironmentInformation {
    name: string;
    buildName: string;
    testResults: TestResults;
}