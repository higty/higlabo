import { ValidationResult } from "../HigLabo/InputPropertyPanel.js";

export class WebApiResult {
    public HttpStatusCode: number;
    public Data: any;
    public Message: string;
    public Url: string;
    public ValidationResultList: Array<ValidationResult>;
}



