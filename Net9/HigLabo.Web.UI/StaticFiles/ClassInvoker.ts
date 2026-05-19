import { $, HtmlElementQuery } from "./HtmlElementQuery.js";

export class ClassInvoker {
    private _InstanceList = {};

    public initialize() {
        $("body").on("click", "[class-invoker='click']", this.classInvoker_Click.bind(this));
        $("body").on("change", "[class-invoker='change']", this.classInvoker_Change.bind(this));
        document.body.addEventListener("htmx:afterRequest", this.htmxAfterRequest.bind(this));
    }

    private classInvoker_Click(target: Element, e: Event) {
        const p = $(target).getAttribute("class-invoker-args");
        this.invoke(p);
    }
    private classInvoker_Change(target: Element, e: Event) {
        const p = $(target).getAttribute("class-invoker-args");
        this.invoke(p);
    }

    private htmxAfterRequest(e: any) {
        const xhr = e.detail.xhr as XMLHttpRequest;
        const serverInvoke = xhr.getResponseHeader("class-invoker-args");
        if (serverInvoke != null) {
            const ss = serverInvoke.split(',');
            for (var i = 0; i < ss.length; i++) {
                this.invoke(ss[i]);
            }
        }
    }

    public addClass(key: string, obj: any) {
        this._InstanceList[key] = obj;
    }
    public invoke(json: string) {
        const r = this.decodeURIComponentAndJsonParse(json);
        if (r.ClassName == "$") {
            this.query(r.Selector, r.FunctionName, r.Args);
        }
        else {
            this.invokeClass(r.ClassName, r.FunctionName, r.Args);
        }
    }

    public invokeClass(className: string, functionName: string, args: string) {
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

    private decodeURIComponentAndJsonParse(json: string) {
        try {
            return JSON.parse(decodeURIComponent(json).replace(/\+/g, " "));
        }
        catch { }
        return alert("JSON parse error.\n" + json);
    }
}