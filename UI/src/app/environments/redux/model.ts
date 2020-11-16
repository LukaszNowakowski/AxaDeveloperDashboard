export interface Link {
  id: number;
  displayName: string;
  url: string;
  icon?: string;
  order: number;
}

export interface Environment {
  id: number;
  displayName: string;
  order: number;
  links: Link[];
}

export interface EnvironmentsModel {
  environments: Environment[];
}
