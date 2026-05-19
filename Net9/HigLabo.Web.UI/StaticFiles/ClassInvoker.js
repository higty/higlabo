import { $ } from "./HtmlElementQuery.js";
export class ClassInvoker {
    _InstanceList = {};
    initialize() {
        $("body").on("click", "[class-invoker='click']", this.classInvoker_Click.bind(this));
        $("body").on("change", "[class-invoker='change']", this.classInvoker_Change.bind(this));
        document.body.addEventListener("htmx:afterRequest", this.htmxAfterRequest.bind(this));
    }
    classInvoker_Click(target, e) {
        const p = $(target).getAttribute("class-invoker-args");
        this.invoke(p);
    }
    classInvoker_Change(target, e) {
        const p = $(target).getAttribute("class-invoker-args");
        this.invoke(p);
    }
    htmxAfterRequest(e) {
        const xhr = e.detail.xhr;
        const serverInvoke = xhr.getResponseHeader("class-invoker-args");
        if (serverInvoke != null) {
            const ss = serverInvoke.split(',');
            for (var i = 0; i < ss.length; i++) {
                this.invoke(ss[i]);
            }
        }
    }
    addClass(key, obj) {
        this._InstanceList[key] = obj;
    }
    invoke(json) {
        const r = this.decodeURIComponentAndJsonParse(json);
        if (r.ClassName == "$") {
            this.query(r.Selector, r.FunctionName, r.Args);
        }
        else {
            this.invokeClass(r.ClassName, r.FunctionName, r.Args);
        }
    }
    invokeClass(className, functionName, args) {
        const o = this._InstanceList[className];
        if (o != null) {
            const f = o[functionName];
            if (f != null) {
                const a = args;
                f.apply(o, Array.isArray(a) ? a : [a]);
            }
        }
    }
    query(selector, functionName, args) {
        const o = $(selector);
        const f = o[functionName];
        if (f == null) {
            return;
        }
        const a = args;
        f.apply(o, Array.isArray(a) ? a : [a]);
    }
    decodeURIComponentAndJsonParse(json) {
        try {
            return JSON.parse(decodeURIComponent(json).replace(/\+/g, " "));
        }
        catch { }
        return alert("JSON parse error.\n" + json);
    }
}
//# sourceMappingURL=ClassInvoker.js.map