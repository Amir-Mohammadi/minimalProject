import { Moment } from "moment"; 'moment';

export class AddUserInput
{
    Id?: number;
    FirstName?: string;
    LastName?: string;
    Email?:string;
    BirthDate?: moment.Moment
    Link?: string;
    
}