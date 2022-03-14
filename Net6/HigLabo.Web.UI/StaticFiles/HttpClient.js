export class HttpClient {
    static get(url, loadCallback, errorCallback, context) {
        const request = new XMLHttpRequest();
        request.open("get", url, true);
        HttpClient.setProperty(request, url, loadCallback, errorCallback, context);
        request.send(null);
    }
    static postJson(url, data, callback, errorCallback, context) {
        const request = new XMLHttpRequest();
        request.open("post", url, true);
        HttpClient.setProperty(request, url, data, callback, errorCallback, context);
        request.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        const json = JSON.stringify(data);
        request.send(json);
    }
    static postForm(url, formData, callback, errorCallback, progressCallback, context) {
        const request = new XMLHttpRequest();
        request.open("post", url, true);
        HttpClient.setProperty(request, url, formData, callback, errorCallback, context);
        if (progressCallback != null) {
            request.upload.addEventListener("progress", progressCallback);
        }
        request.send(formData);
    }
    static setProperty(request, url, requestData, callback, errorCallback, context) {
        const csrfToken = HttpClient.getCsrfToken();
        if (csrfToken != "") {
            request.setRequestHeader("CsrfToken", csrfToken);
        }
        request.onload = function (event) {
            if (callback == null) {
                return;
            }
            if (request.status < 400) {
                callback(new HttpResponse(request, url, requestData), context);
            }
            else {
                if (errorCallback == null) {
                    if (HttpClient.errorCallback != null) {
                        HttpClient.errorCallback(new HttpResponse(request, url, requestData), context);
                    }
                    return;
                }
                errorCallback(new HttpResponse(request, url, requestData), context);
            }
        };
        request.onerror = function (event) {
            if (errorCallback == null) {
                if (HttpClient.errorCallback != null) {
                    HttpClient.errorCallback(new HttpResponse(request, url, requestData), context);
                }
                return;
            }
            errorCallback(new HttpResponse(request, url, requestData), context);
        };
    }
    static getCsrfToken() {
        if (document.getElementById("CsrfToken") != null) {
            return document.getElementById("CsrfToken").getAttribute("value");
        }
        return "";
    }
}
export class HttpResponse {
    constructor(request, url, requestData) {
        this.xmlHttpRequest = request;
        this.url = url;
        this.requestData = requestData;
        this.status = request.status;
        this.responseText = request.responseText;
    }
    jsonParse() {
        try {
            return JSON.parse(this.responseText);
        }
        catch (ex) {
            console.log("JSON parse error. \r\n" + this.responseText);
        }
    }
    getWebApiResult() {
        return this.jsonParse();
    }
}
//# sourceMappingURL=HttpClient.js.map