export class HttpClient {
    public static errorCallback: HttpRequestCallback;

    public static get(url: string, loadCallback: HttpRequestCallback, errorCallback?: HttpRequestCallback, context?: any) {
        const request = new XMLHttpRequest();
        request.open("get", url, true);
        HttpClient.setProperty(request, loadCallback, errorCallback, context);
        request.send(null);
    }
    public static postJson(url: string, data: any, callback?: HttpRequestCallback, errorCallback?: HttpRequestCallback
        , context?: any) {
        const request = new XMLHttpRequest();
        request.open("post", url, true);
        HttpClient.setProperty(request, data, callback, errorCallback, context);

        request.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        const json = JSON.stringify(data);
        request.send(json);
    }
    public static postForm(url: string, formData: FormData, callback?: HttpRequestCallback, errorCallback?: HttpRequestCallback
        , progressCallback?: EventListener, context?: any) {
        const request = new XMLHttpRequest();
        request.open("post", url, true);
        HttpClient.setProperty(request, callback, errorCallback, context);

        if (progressCallback != null) {
            request.upload.addEventListener("progress", progressCallback);
        }
        request.send(formData);
    }
    private static setProperty(request: XMLHttpRequest, requestData: any
        , callback?: HttpRequestCallback, errorCallback?: HttpRequestCallback, context?: any) {
        const csrfToken = HttpClient.getCsrfToken();
        if (csrfToken != "") {
            request.setRequestHeader("CsrfToken", csrfToken);
        }
        request.onload = function (event) {
            if (callback == null) { return; }
            if (request.status < 400) {
                callback(new HttpResponse(request, requestData), context);
            }
            else {
                if (errorCallback == null) {
                    if (HttpClient.errorCallback != null) {
                        HttpClient.errorCallback(new HttpResponse(request, requestData), context);
                    }
                    return;
                }
                errorCallback(new HttpResponse(request, requestData), context);
            }
        };
        request.onerror = function (event) {
            if (errorCallback == null) {
                if (HttpClient.errorCallback != null) {
                    HttpClient.errorCallback(new HttpResponse(request, requestData), context);
                }
                return;
            }
            errorCallback(new HttpResponse(request, requestData), context);
        };
    }
    public static getCsrfToken() {
        if (document.getElementById("CsrfToken") != null) {
            return document.getElementById("CsrfToken").getAttribute("value");
        }
        return "";
    }
}

export class HttpResponse {
    public xmlHttpRequest: XMLHttpRequest;
    public requestData: any;
    public status: number;
    public responseText: string;

    constructor(request: XMLHttpRequest, requestData: any) {
        this.xmlHttpRequest = request;
        this.requestData = requestData;
        this.status = request.status;
        this.responseText = request.responseText;
    }
    public jsonParse(): any {
        try {
            return JSON.parse(this.responseText);
        }
        catch (ex) {
            console.log("JSON parse error. \r\n" + this.responseText);
        }
    }
}
export interface HttpRequestCallback {
    (response: HttpResponse, context: any): void;
}

