export class HttpClient {
    send(request) {
        const req = request;
        const xReq = new XMLHttpRequest();
        xReq.open(req.httpMethod, req.url, true);
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
    get(url, callback, errorCallback, context) {
        const req = new HttpRequest("get", url, callback, errorCallback);
        req.context = context;
        this.send(req);
    }
    postJson(url, data, callback, errorCallback, context) {
        const req = new HttpPostJsonRequest(url, data, callback, errorCallback);
        req.context = context;
        this.send(req);
    }
    postForm(url, formData, callback, errorCallback, progressCallback, context) {
        const req = new HttpPostFormRequest(url, formData, callback, errorCallback);
        if (progressCallback != null) {
            req.progressCallback = progressCallback;
        }
        req.context = context;
        this.send(req);
    }
    setProperty(xmlHttpRequest, request) {
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
    invokeCallback(response) {
        const req = response.request;
        for (var i = 0; i < req.callback.length; i++) {
            if (req.callback[i] == null) {
                continue;
            }
            req.callback[i](response);
        }
    }
    invokeErrorCallback(response) {
        const req = response.request;
        for (var i = 0; i < req.errorCallback.length; i++) {
            if (req.errorCallback[i] == null) {
                continue;
            }
            req.errorCallback[i](response);
        }
    }
}
export class HttpRequest {
    httpMethod = "";
    url = "";
    contentType = "";
    data;
    context;
    callback = new Array();
    errorCallback = new Array();
    progressCallback;
    constructor(httpMethod, url, callback, errorCallback) {
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
export class HttpPostJsonRequest extends HttpRequest {
    constructor(url, data, callback, errorCallback) {
        super("post", url, callback, errorCallback);
        this.data = data;
        this.contentType = "application/json; charset=utf-8";
    }
}
export class HttpPostFormRequest extends HttpRequest {
    constructor(url, data, callback, errorCallback) {
        super("post", url, callback, errorCallback);
        this.data = data;
        this.callback.push(callback);
        if (errorCallback != null) {
            this.errorCallback.push(errorCallback);
        }
    }
}
export class HttpResponse {
    xmlHttpRequest;
    request;
    status;
    responseText;
    constructor(xmlHttpRequest, request) {
        this.xmlHttpRequest = xmlHttpRequest;
        this.request = request;
        this.status = xmlHttpRequest.status;
        this.responseText = xmlHttpRequest.responseText;
    }
    jsonParse() {
        try {
            return JSON.parse(this.responseText);
        }
        catch (ex) {
            console.log("JSON parse error. \r\n" + this.responseText);
        }
    }
    createWebApiResult() {
        try {
            return JSON.parse(this.responseText);
        }
        catch (ex) {
            console.log("JSON parse error. \r\n" + this.responseText);
        }
    }
}
export class WebApiResult {
    HttpStatusCode;
    HttpStatus;
    DataType;
    Data;
}
//# sourceMappingURL=HttpClient.js.map