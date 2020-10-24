export interface GenericCommandResult<T> {
    sucess: boolean;
    message: string;
    data: T;
}