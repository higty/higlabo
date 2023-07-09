export class HttpClient {

    public send(request: HttpRequest) {
        const req = request;
        const xReq = new XMLHttpRequest();
        xReq.open(req.httpMethod, req.url, true);
        req.headers.forEach(header => {
            xReq.setRequestHeader(header.name, header.value);
        });
        this.setProperty(xReq, req);
        if (req.progressCallback != null) {
            xReq.upload.addEventListener("progress", req.progressCallback);
        }

        if (req.data == null) {
            xReq.send(null);
        }
        else {
            if (req.contentType != "") {
                xReq.setRequestHeader("Content-Type", req.contentType);
            }
            if (req instanceof HttpPostJsonRequest) {
                xReq.send(JSON.stringify(req.data));
            }
            else {
                xReq.send(req.data);
            }
        }
    }

    public get(url: string, callback: HttpRequestCallback, errorCallback?: HttpRequestCallback, context?: any) {
        const req = new HttpRequest("get", url, callback, errorCallback);
        req.context = context;
        this.send(req);
    }
    public postJson(url: string, data: any, callback: HttpRequestCallback, errorCallback?: HttpRequestCallback, context?: any) {
        const req = new HttpPostJsonRequest(url, data, callback, errorCallback);
        req.context = context;
        this.send(req);
    }
    public postForm(url: string, formData: FormData, callback: HttpRequestCallback, errorCallback?: HttpRequestCallback, progressCallback?: EventListener, context?: any) {
        const req = new HttpPostFormRequest(url, formData, callback, errorCallback);
        if (progressCallback != null) {
            req.progressCallback = progressCallback;
        }
        req.context = context;
        this.send(req);
    }
    public setProperty(xmlHttpRequest: XMLHttpRequest, request: HttpRequest) {
        const cl = this;

        xmlHttpRequest.onload = function (event) {
            if (xmlHttpRequest.status < 400) {
                cl.invokeCallback(new HttpResponse(xmlHttpRequest, request));
            }
            else {
                cl.invokeErrorCallback(new HttpResponse(xmlHttpRequest, request));
            }
        }.bind(this);
        xmlHttpRequest.onerror = function (event) {
            cl.invokeErrorCallback(new HttpResponse(xmlHttpRequest, request));
        }.bind(this);
    }
    private invokeCallback(response: HttpResponse) {
        const req = response.request;
        for (var i = 0; i < req.callback.length; i++) {
            if (req.callback[i] == null) { continue; }
            req.callback[i](response);
        }
    }
    private invokeErrorCallback(response: HttpResponse) {
        const req = response.request;
        for (var i = 0; i < req.errorCallback.length; i++) {
            if (req.errorCallback[i] == null) { continue; }
            req.errorCallback[i](response);
        }
    }
}

export class HttpRequest {
    public httpMethod = "";
    public url = "";
    public contentType = "";
    public headers = new Array<HttpRequestHeader>();
    public data: any;
    public context: any;
    public callback = new Array<HttpRequestCallback>();
    public errorCallback = new Array<HttpRequestCallback>();
    public progressCallback: EventListener;

    constructor(httpMethod: string, url: string, callback?: HttpRequestCallback, errorCallback?: HttpRequestCallback) {
        this.httpMethod = httpMethod;
        this.url = url;
        if (callback != null) {
            this.callback.push(callback);
        }
        if (errorCallback != null) {
            this.errorCallback.push(errorCallback);
        }
    }
}
export class HttpRequestHeader {
    public name = "";
    public value = "";

    constructor(name: string, value: string) {
        this.name = name;
        this.value = value;
    }
}

export class HttpPostJsonRequest extends HttpRequest {
    constructor(url: string, data: any, callback?: HttpRequestCallback, errorCallback?: HttpRequestCallback) {
        super("post", url, callback, errorCallback);
        this.data = data;
        this.contentType = "application/json; charset=utf-8";
    }
}
export class HttpPostFormRequest extends HttpRequest {
    constructor(url: string, data: FormData, callback: HttpRequestCallback, errorCallback?: HttpRequestCallback) {
        super("post", url, callback, errorCallback);
        this.data = data;
    }
}


export class HttpResponse {
    public xmlHttpRequest: XMLHttpRequest;
    public request: HttpRequest;
    public status: number;
    public responseText: string;

    constructor(xmlHttpRequest: XMLHttpRequest, request: HttpRequest) {
        this.xmlHttpRequest = xmlHttpRequest;
        this.request = request;
        this.status = xmlHttpRequest.status;
        this.responseText = xmlHttpRequest.responseText;
    }
    public jsonParse(): any {
        try {
            return JSON.parse(this.responseText);
        }
        catch (ex) {
            console.log("JSON parse error. \r\n" + this.responseText);
        }
    }
    public createWebApiResult(): WebApiResult {
        try {
            return JSON.parse(this.responseText) as WebApiResult;
        }
        catch (ex) {
            console.log("JSON parse error. \r\n" + this.responseText);
        }
    }
}
export interface HttpRequestCallback {
    (response: HttpResponse): void;
}

export class WebApiResult {
    public HttpStatusCode: number;
    public HttpStatus: string;
    public DataType: string;
    public Data: any;
}



