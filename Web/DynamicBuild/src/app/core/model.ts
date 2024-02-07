export interface Word {
    id: string;
    value: string;
    wordTypeId: string;
}

export interface Sentence {
    content: string;
}

export interface WordTypeDropdownItem {
    code: string;
    name: string;
}

export interface WordDropdownItem {
    code: string;
    name: string;
}

export interface ApiResponse<T> {
    isSuccess: boolean;
    value: T[];
    error: string | null;
  }
  

  export interface Pagination {
    currentPage: number;
    itemsPerPage: number;
    totalItems: number;
    totalPages: number;
}

export class PaginatedResult<T> {
    result?: T;
    pagination?: Pagination
}