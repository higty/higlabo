import { $, HtmlElementQuery } from "./HtmlElementQuery.js";

export class ServerClass {
    private _InstanceList = {};

    public initialize() {
        document.body.addEventListener("htmx:afterRequest", this.afterRequest.bind(this));
    }

    public add(key: string, obj: any) {
        this._InstanceList[key] = obj;
    }
    public invoke(className: string, functionName: string, args: string) {
        const o = this._InstanceList[className];
        if (o != null) {
            const f = (o as any)[functionName] as Function;
            if (f != null) {
                const a = args;
                f.apply(o, Array.isArray(a) ? a : [a]);
            }
        }
    }
    public query(selector: string, functionName: string, args: string) {
        const o = $(selector);
        const f = (o as any)[functionName] as Function;
        if (f == null) { return; }
        const a = args;
        f.apply(o, Array.isArray(a) ? a : [a]);
    }

    private afterRequest(e: any) {
        const xhr = e.detail.xhr as XMLHttpRequest;
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
    private decodeURIComponentAndJsonParse(json: string) {
        try {
            return JSON.parse(decodeURIComponent(json).replace(/\+/g, " "));
        }
        catch { }
        return alert("JSON parse error.\n" + json);
    }
}