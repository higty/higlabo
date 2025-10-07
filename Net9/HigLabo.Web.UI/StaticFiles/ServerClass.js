import { $ } from "./HtmlElementQuery.js";
export class ServerClass {
    _InstanceList = {};
    initialize() {
        document.body.addEventListener("htmx:afterRequest", this.afterRequest.bind(this));
    }
    add(key, obj) {
        this._InstanceList[key] = obj;
    }
    invoke(className, functionName, args) {
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
    afterRequest(e) {
        const xhr = e.detail.xhr;
        const serverInvoke = xhr.getResponseHeader("server-invoke");
        if (serverInvoke != null) {
            const ss = serverInvoke.split(',');
            for (var i = 0; i < ss.length; i++) {
                const r = this.decodeURIComponentAndJsonParse(ss[i]);
                if (r.ClassName == "$") {
                    this.query(r.Selector, r.FunctionName, r.Args);
                }
                else {
                    this.invoke(r.ClassName, r.FunctionName, r.Args);
                }
            }
        }
    }
    decodeURIComponentAndJsonParse(json) {
        try {
            return JSON.parse(decodeURIComponent(json).replace(/\+/g, " "));
        }
        catch { }
        return alert("JSON parse error.\n" + json);
    }
}
//# sourceMappingURL=ServerClass.js.map