var HttpClient = (function () {
    function HttpClient() {
    }
    HttpClient.get = function (url, loadCallback, errorCallback, context) {
        var request = new XMLHttpRequest();
        request.open("get", url, true);
        HttpClient.setProperty(request, loadCallback, errorCallback, context);
        request.send(null);
    };
    HttpClient.postJson = function (url, data, callback, errorCallback, context) {
        var request = new XMLHttpRequest();
        request.open("post", url, true);
        HttpClient.setProperty(request, callback, errorCallback, context);
        request.setRequestHeader("Content-Type", "application/json; charset=utf-8");
        var json = JSON.stringify(data);
        request.send(json);
    };
    HttpClient.postForm = function (url, formData, callback, errorCallback, progressCallback, context) {
        var request = new XMLHttpRequest();
        request.open("post", url, true);
        HttpClient.setProperty(request, callback, errorCallback, context);
        if (progressCallback != null) {
            request.upload.addEventListener("progress", progressCallback);
        }
        request.send(formData);
    };
    HttpClient.setProperty = function (request, callback, errorCallback, context) {
        request.setRequestHeader("CsrfToken", document.getElementById("CsrfToken").getAttribute("value"));
        request.onload = function (event) {
            if (callback == null) {
                return;
            }
            if (request.status < 400) {
                callback(new HttpResponse(request), context);
            }
            else {
                if (errorCallback == null) {
                    if (HttpClient.errorCallback != null) {
                        HttpClient.errorCallback(new HttpResponse(request), context);
                    }
                    return;
                }
                errorCallback(new HttpResponse(request), context);
            }
        };
        request.onerror = function (event) {
            if (errorCallback == null) {
                if (HttpClient.errorCallback != null) {
                    HttpClient.errorCallback(new HttpResponse(request), context);
                }
                return;
            }
            errorCallback(new HttpResponse(request), context);
        };
    };
    return HttpClient;
}());
export { HttpClient };
var HttpResponse = (function () {
    function HttpResponse(request) {
        this.xmlHttpRequest = request;
        this.status = request.status;
        this.responseText = request.responseText;
    }
    HttpResponse.prototype.jsonParse = function () {
        return JSON.parse(this.responseText);
    };
    return HttpResponse;
}());
export { HttpResponse };
//# sourceMappingURL=HttpClient.js.map